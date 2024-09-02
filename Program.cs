using System;
using WIA;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Crear un objeto Device Manager para gestionar dispositivos WIA
            DeviceManager deviceManager = new DeviceManager();
            Device device = null;

            // Encontrar un dispositivo WIA
            foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos)
            {
                if (deviceInfo.Type == WiaDeviceType.ScannerDeviceType)
                {
                    device = deviceInfo.Connect();
                    break;
                }
            }

            if (device == null)
            {
                Console.WriteLine("No se encontró ningún escáner.");
                return;
            }

            // Escanear
            Item item = device.Items[1];
            //Console.WriteLine(item.Properties);

            // Especificar el formato de imagen como una cadena de texto
            //string formatID = "JPEG"; // Usar la cadena para el formato JPEG

            // Transferir la imagen en el formato especificado
            ImageFile imageFile = (ImageFile)item.Transfer(FormatID.wiaFormatJPEG);

            // Guardar la imagen en el disco
            string outputPath = "C:\\Users\\Timo\\source\\repos\\escaner\\img\\scanned_image3.jpg";
            imageFile.SaveFile(outputPath);

            Console.WriteLine($"Imagen escaneada y guardada en: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}



