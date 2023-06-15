using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NAudio;
using NAudio.Wave;

namespace C_LAB6
{
    public partial class LB6 : Form
    {
        public string filePath = ""; // Зберігає шлях до вибраного аудіофайлу
        public HttpClient client = new HttpClient(); // HttpClient для взаємодії з сервером
        public string backendUrl = "http://localhost:8080"; // URL сервера
        private bool isPlaying = false; // Прапорець, що вказує, чи відбувається відтворення аудіофайлу
        private WaveOut waveOut; // Об'єкт WaveOut для відтворення аудіо

        private const int UdpPort = 12345; // Порт для UDP-з'єднання
        private const string ServerIPAddress = "127.0.0.1"; // IP-адреса сервера
        private const int Port = 12345; // Порт для UDP-з'єднання

        public LB6()
        {
            InitializeComponent();
        }

        private void select_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
            openFileDialog.Title = "Select an MP3 File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                filePath = selectedFilePath;
                file.Text = selectedFilePath;
            }
        }

        private void upload_file_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] fileData = File.ReadAllBytes(filePath); // Зчитування даних з аудіофайлу

                ByteArrayContent fileContent = new ByteArrayContent(fileData);
                HttpResponseMessage response = client.PostAsync($"{backendUrl}/add-audio", fileContent).Result; // Відправка POST-запиту з аудіоданими на сервер

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Audio file uploaded successfully.");
                }
                else
                {
                    Console.WriteLine($"Error uploading audio file. Status Code: {response.StatusCode}");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }
        }

        private async void update_files_list_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = await client.GetAsync($"{backendUrl}/get-audios"); // Відправка GET-запиту на сервер для отримання списку аудіофайлів

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                string[] audios = JsonSerializer.Deserialize<string[]>(json);

                files_list.Items.Clear();

                foreach (string audio in audios)
                {
                    files_list.Items.Add(audio);
                }
            }
            else
            {
                Console.WriteLine($"Error getting audios. Status Code: {response.StatusCode}");
            }
        }

        private void HandleUdp(string FilePath)
        {
            using (UdpClient udpClient = new UdpClient())
            {
                IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse(ServerIPAddress), Port);

                try
                {
                    byte[] filePathBytes = Encoding.UTF8.GetBytes(FilePath);

                    udpClient.Send(filePathBytes, filePathBytes.Length, serverEndpoint); // Відправка шляху аудіофайлу на сервер через UDP-з'єднання

                    byte[] audioData = udpClient.Receive(ref serverEndpoint); // Отримання аудіоданих з сервера

                    using (MemoryStream stream = new MemoryStream(audioData))
                    {
                        Mp3FileReader reader = new Mp3FileReader(stream);
                        waveOut = new WaveOut();
                        waveOut.Init(reader);
                        waveOut.Play(); // Відтворення аудіофайлу

                        // Очікування завершення відтворення
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100);
                        }

                        waveOut.Stop();
                        waveOut.Dispose();
                        waveOut = null;
                        reader.Dispose();
                        reader = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
            }
        }

        private void play_selected_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isPlaying) // Перевірка, чи не відбувається вже відтворення аудіофайлу
                {
                    string selectedItem = files_list.SelectedItem?.ToString();

                    if (!string.IsNullOrEmpty(selectedItem))
                    {
                        if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            waveOut.Stop();
                            waveOut.Dispose();
                            waveOut = null;
                        }

                        Thread udpThread = new Thread(() =>
                        {
                            isPlaying = true;
                            HandleUdp(selectedItem); // Відтворення вибраного аудіофайлу
                            isPlaying = false;
                        });
                        udpThread.Start();
                    }
                    else
                    {
                        MessageBox.Show("Please select an audio file to play.");
                    }
                }
                else
                {
                    MessageBox.Show("Audio is already playing.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error can't play audio. Status Code: {ex.Message}");
            }
        }


    }
}
