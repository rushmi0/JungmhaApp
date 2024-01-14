using JungmhaApp.form;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace JungmhaApp.service
{
    public class DogWalkerAPIService
    {
        // URL ของ API ที่ใช้รับข้อมูล Walker
        private readonly string WebAPIUrl = "http://10.0.2.2:8080/api/v1/home/filter";

        // HttpClient สำหรับเรียก API
        private readonly HttpClient client;

        // กำหนดค่าเริ่มต้นใน Constructor
        public DogWalkerAPIService()
        {
            // ปรับใช้ HttpClientHandler เพื่อรองรับทั้ง Android และ iOS
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseProxy = false;

            client = new HttpClient(httpClientHandler);
            client.Timeout = TimeSpan.FromSeconds(30); 
        }

        // ส่วนที่ใช้ Refresh ข้อมูล Walker จาก API
        public async Task<ObservableCollection<WalkerForm.Walker>> RefreshDataAsync()
        {
            try
            {
                // เรียก API ด้วย HttpClient
                var response = await client.GetAsync(WebAPIUrl);

                // ถ้าเรียก API สำเร็จ
                if (response.IsSuccessStatusCode)
                {
                    // ดึงข้อมูลที่ได้มาในรูปแบบของ JSON
                    var content = await response.Content.ReadAsStringAsync();

                    // แปลง JSON เป็น C# Object ตามรูปแบบที่กำหนดจาก Walker
                    return JsonConvert.DeserializeObject<ObservableCollection<WalkerForm.Walker>>(content);
                }
            }
            catch (Exception ex)
            {
                // แสดงข้อผิดพลาดที่เกิดขึ้น
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Trace: {ex.StackTrace}");
            }

            // ถ้ามีข้อผิดพลาดในกระบวนการของ API หรือการแปลง JSON ให้คืนค่า null
            return null;
        }
    }
}
