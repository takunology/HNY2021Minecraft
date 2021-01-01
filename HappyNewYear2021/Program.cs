using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CoreRCON;

namespace HappyNewYear2021
{
    class Program
    {
        static RCON rcon = new RCON(IPAddress.Parse("127.0.0.1"), 25575, "minecraft");

        static void Main(string[] args)
        {
            Task.Run(async () => {
                await HNY();
                await Fireworks();
            }).GetAwaiter().GetResult();
        }

        static async Task HNY()
        {
            string title = "Happy New Year!";
            string sub = "- 2021 -";

            await rcon.ConnectAsync();
            await rcon.SendCommandAsync($"/title @a subtitle \"{sub}\" ");
            await rcon.SendCommandAsync($"/title @a title \"{title}\" ");
        }

        static async Task Fireworks()
        {
            List<string> firework = new List<string>
            {
                "/summon firework_rocket 380 100 718 {LifeTime:15,FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:2,Explosions:[{Type:1,Flicker:0,Trail:0,Colors:[I;3887386],FadeColors:[I;11743532]}]}}}}",
                "/summon firework_rocket 380 99 723 {LifeTime:15,FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:2,Explosions:[{Type:1,Flicker:0,Trail:0,Colors:[I;11743532,3887386],FadeColors:[I;11743532,4408131]}]}}}}",
                "/summon firework_rocket 380 99 713 {LifeTime:15,FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:2,Explosions:[{Type:1,Flicker:0,Trail:0,Colors:[I;2437522],FadeColors:[I;4312372]}]}}}}",
                "/summon firework_rocket 380 98 728 {LifeTime:15,FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:2,Explosions:[{Type:1,Flicker:0,Trail:0,Colors:[I;15790320],FadeColors:[I;14602026]}]}}}}",
                "/summon firework_rocket 380 100 708 {LifeTime:15,FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:2,Explosions:[{Type:1,Flicker:0,Trail:0,Colors:[I;15435844],FadeColors:[I;15790320]}]}}}}"
            };

            await rcon.ConnectAsync();

            for(int i = 0; i < 3; i++)
            {
                foreach (var item in firework)
                {
                    await rcon.SendCommandAsync(item);
                    await Task.Delay(100);
                }
                await Task.Delay(1000);
            }
        }
    }
}