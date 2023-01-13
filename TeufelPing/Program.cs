using NAudio.Wave;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TeufelPing
{
    public static class Program
    {
        private static string devOut = "Microsoft Sound Mapper";
        private static readonly Dictionary<string, int> deviceList = new();

        public static void Main()
        {
            ReportDevices();
            LoadConfig();
            PlaySound();
        }

        private static void PlaySound()
        {
            CancellationTokenSource source = new();
            CancellationToken token = source.Token;

            while (!token.IsCancellationRequested)
            {
                var audioFile = new AudioFileReader("SilentNoise.wav");
                var outputDevice = new WaveOutEvent();
                outputDevice.DeviceNumber = GetDeviceNumber();
                outputDevice.Init(audioFile);
                outputDevice.Play();
                Thread.Sleep(600000);
                outputDevice.Dispose();
                audioFile.Dispose();
            }
            
        }

        private static int GetDeviceNumber()
        {
            for (int n = -1; n < WaveOut.DeviceCount; n++)
            {
                if (WaveOut.GetCapabilities(n).ProductName == devOut)
                    return n;
            }

            return -1;
        }

        private static void LoadConfig()
        {
            if (File.Exists("device.cfg"))
            {
                string name = File.ReadLines("device.cfg").First().Trim();
                if (deviceList.ContainsKey(name))
                    devOut = name;
            }
        }

        private static void ReportDevices()
        {
            StringBuilder sb = new();
            for (int n = -1; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                sb.AppendLine($"Device {n}: [{caps.ProductName}]");
                deviceList.Add(caps.ProductName, n);
            }

            File.WriteAllText("devices.txt", sb.ToString(), Encoding.UTF8);
        }
    }
}