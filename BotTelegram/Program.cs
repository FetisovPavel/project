using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading.Tasks;
using System.Data.SQLite;
using Telegram.Bot.Types.InputFiles;
using System.IO;
namespace BotTelegram
{
    class Program
    {
        const string TOKEN = "2048412522:AAF_NSrBCn7fUI38l0L4pMN356I6Eirc6gc";
        public static SQLiteConnection DB1;
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    GetMessages().Wait();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: "+ ex);
                }
            }
        }
        static async Task GetMessages()
        {
            TelegramBotClient bot = new TelegramBotClient(TOKEN);
            int offset = 0;
            int timeout = 0;
            int c = 0;
            int g = 0;
            int m = 0;
            try
            {
                await bot.SetWebhookAsync("");
                while (true)
                {
                    var updates = await bot.GetUpdatesAsync(offset, timeout);

                    foreach(var update in updates)
                    {
                        var message = update.Message;
                        if (message.Text == "/start")
                        {
                            Registration(message.Chat.Id.ToString(), message.Chat.Username.ToString());
                            Console.WriteLine("Вашей программой кто-то начал пользоваться");
                            Console.WriteLine("Пользователь сохранен в вашу базу данных");
                            Console.WriteLine("Получено сообщение:" + message.Text);
                            var keyboard = new ReplyKeyboardMarkup
                            {
                                Keyboard = new[]
                                {
                                    new[] {
                                        new KeyboardButton("дай стикер\U0001F601"),
                                        new KeyboardButton("Привет\U0001F60D")
                                    },
                                }
                            };
                            await bot.SendTextMessageAsync(message.Chat.Id, "Привет, я твой бот! " + message.Chat.Username, ParseMode.Html, null ,false, false, 0, false,keyboard);
                        }
                        if (message.Text == "Привет\U0001F60D")
                        {
                            var sticker = new InputOnlineFile("CAACAgIAAxkBAAEDIw5hdBaRiQIaMH8NchPBiXN_QwTLvgACBQADwDZPE_lqX5qCa011IQQ");
                            await bot.SendStickerAsync(message.Chat.Id, sticker);
                            await bot.SendTextMessageAsync(message.Chat.Id, "Погнали выбирать тебе видеокарту!!! Для каких задач тебе она нужна?");
                            var keyboard = new ReplyKeyboardMarkup
                            {
                                Keyboard = new[]
                                {
                                    new[] {
                                        new KeyboardButton("для майнинга\U0001F601"),
                                        new KeyboardButton("для игр\U0001F60D"),
                                        new KeyboardButton("для моделирования\U0001F60B"),
                                    },
                                }
                            };
                            await bot.SendTextMessageAsync(message.Chat.Id, "Буду благодарен, если воспользуешься панельками\U0001F601" + message.Chat.Username, ParseMode.Html, null, false, false, 0, false, keyboard);
                        }
                        if (message.Text == "дай стикер\U0001F601")
                        {
                            var sticker = new InputOnlineFile("CAACAgIAAxkBAAEDG7dhbYuRCk6kEXB6Qw4CtBKAUFebmwACEQADOW9OJhAtX5wMXKDwIQQ");
                            await bot.SendStickerAsync(message.Chat.Id, sticker);
                        }
                        if (message.Text == "/restart")
                        {
                            Console.WriteLine("Получено сообщение:" + message.Text);
                            var keyboard = new ReplyKeyboardMarkup
                            {
                                Keyboard = new[]
                                {
                                    new[] {
                                        new KeyboardButton("для майнинга\U0001F601"),
                                        new KeyboardButton("для игр\U0001F60D"),
                                        new KeyboardButton("для моделирования\U0001F60B")
                                    },
                                }
                            };
                            await bot.SendTextMessageAsync(message.Chat.Id, "Так, какую видеокарту еще тебе ищем? ", ParseMode.Html, null, false, false, 0, false, keyboard);
                        }
                        if (message.Text == "для майнинга\U0001F601")
                        {
                            c = 1;
                            await bot.SendTextMessageAsync(message.Chat.Id, "Крутой))) Можешь, пожалуйста, прислать свой бюджет, а я посмотрю, что тебе предложить");
                            var keyboard = new ReplyKeyboardMarkup
                            {
                                Keyboard = new[]
                                {
                                    new[] {
                                        new KeyboardButton("ок\U0001F600"),
                                        new KeyboardButton("хорошо\U0001F611")
                                    },
                                }
                            };
                            await bot.SendTextMessageAsync(message.Chat.Id, "Набери, пожалуйста, на клавиатуре, " + message.Chat.Username, ParseMode.Html, null, false, false, 0, false, keyboard);
                        }
                        if (message.Text == "для игр\U0001F60D")
                        {
                            g = 1;
                            await bot.SendTextMessageAsync(message.Chat.Id, "Надеюсь не для доты.... Можешь, пожалуйста, прислать свой бюджет, а я посмотрю, что тебе предложить");
                            var keyboard = new ReplyKeyboardMarkup
                            {
                                Keyboard = new[]
                                {
                                    new[] {
                                        new KeyboardButton("ок\U0001F600"),
                                        new KeyboardButton("хорошо\U0001F611")
                                    },
                                }
                            };
                            await bot.SendTextMessageAsync(message.Chat.Id, "Набери, пожалуйста, на клавиатуре, " + message.Chat.Username, ParseMode.Html, null, false, false, 0, false, keyboard);
                        }
                        if (message.Text == "для моделирования\U0001F60B")
                        {
                            m = 1;
                            await bot.SendTextMessageAsync(message.Chat.Id, "Воу, класс! Можешь, пожалуйста, прислать свой бюджет, а я посмотрю, что тебе предложить");
                            var keyboard = new ReplyKeyboardMarkup
                            {
                                Keyboard = new[]
                                {
                                    new[] {
                                        new KeyboardButton("ок\U0001F600"),
                                        new KeyboardButton("хорошо\U0001F611")
                                    },
                                }
                            };
                            await bot.SendTextMessageAsync(message.Chat.Id, "Набери, пожалуйста, на клавиатуре, " + message.Chat.Username, ParseMode.Html, null, false, false, 0, false, keyboard);
                        }
                        if (message.Text == "ок\U0001F600" || message.Text == "хорошо\U0001F611")
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Жду твоего запроса....\U0001F634");
                        }
                        int g3;
                        bool result = int.TryParse(message.Text, out g3);
                        if(result == true && c==1)
                        {
                            c = 0;
                            if (Convert.ToInt32(message.Text) > 300000)
                            {
                                await SendFile(bot, message);
                                var keyboard = new ReplyKeyboardMarkup
                                {
                                    Keyboard = new[]
                                    {
                                    new[] {
                                        new KeyboardButton("/restart"),
                                    },
                                }
                                };
                                await bot.SendTextMessageAsync(message.Chat.Id, "Надеюсь, я помог тебе с выбором, " + message.Chat.Username, ParseMode.Html, null, false, false, 0, false, keyboard);
                            }
                            if (Convert.ToInt32(message.Text) >= 60000 && Convert.ToInt32(message.Text) <= 70000)
                            {
                                await SendFile3(bot, message);
                                var keyboard = new ReplyKeyboardMarkup
                                {
                                    Keyboard = new[]
                                    {
                                    new[] {
                                        new KeyboardButton("/restart"),
                                    },
                                }
                                };
                                await bot.SendTextMessageAsync(message.Chat.Id, "Надеюсь, я помог тебе с выбором, " + message.Chat.Username, ParseMode.Html, null, false, false, 0, false, keyboard);
                            }
                        }
                        if (result == true && g == 1)
                        {
                            g = 0;
                            if (Convert.ToInt32(message.Text) <=70000 && Convert.ToInt32(message.Text) >= 60000)
                            {
                                await SendFile1(bot, message);
                                var keyboard = new ReplyKeyboardMarkup
                                {
                                    Keyboard = new[]
                                    {
                                    new[] {
                                        new KeyboardButton("/restart"),
                                    },
                                }
                                };
                                await bot.SendTextMessageAsync(message.Chat.Id, "Надеюсь, я помог тебе с выбором, " + message.Chat.Username, ParseMode.Html, null, false, false, 0, false, keyboard);
                            }
                        }
                        if (result == true && m == 1)
                        {
                            m = 0;
                            if (Convert.ToInt32(message.Text) <= 70000 && Convert.ToInt32(message.Text) >= 60000)
                            {
                                await SendFile2(bot, message);
                                var keyboard = new ReplyKeyboardMarkup
                                {
                                    Keyboard = new[]
                                    {
                                    new[] {
                                        new KeyboardButton("/restart"),
                                    },
                                }
                                };
                                await bot.SendTextMessageAsync(message.Chat.Id, "Надеюсь, я помог тебе с выбором, " + message.Chat.Username, ParseMode.Html, null, false, false, 0, false, keyboard);
                            }
                        }
                        offset = update.Id + 1;
                    }
                }
            }
            catch(Exception ex){
                Console.WriteLine("Error: " + ex);
            }
        }

        public static void Registration(string ID, string Name)
        {
            try
            {
                DB1 = new SQLiteConnection("Data Source=DB1.db;");
                DB1.Open();
                SQLiteCommand regcmd = DB1.CreateCommand();
                regcmd.CommandText = "INSERT INTO Bot([ID], [Name]) VALUES(@ID, @Name)";
                regcmd.Parameters.AddWithValue("@ID", ID);
                regcmd.Parameters.AddWithValue("@Name", Name);
                regcmd.ExecuteNonQuery();
                DB1.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: "+ ex);
            }
        }
        static async Task SendFile(TelegramBotClient bot, Message message)
        {
            var info = new DirectoryInfo(@"C:\Data\miner\300000\");
            try
            {
                FileInfo[] fileInfoGroup = info.GetFiles();
                foreach (var fileInfo in fileInfoGroup)
                {
                    var fileStream = new FileStream(fileInfo.FullName, FileMode.Open);
                    var file = new InputOnlineFile(fileStream,"RTX3090.txt");
                    await bot.SendDocumentAsync(message.Chat.Id, file);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
        static async Task SendFile1(TelegramBotClient bot, Message message)
        {
            var info = new DirectoryInfo(@"C:\Data\game\60000-70000\");
            try
            {
                FileInfo[] fileInfoGroup = info.GetFiles();
                foreach (var fileInfo in fileInfoGroup)
                {
                    var fileStream = new FileStream(fileInfo.FullName, FileMode.Open);
                    var file = new InputOnlineFile(fileStream, "Sapphire AMD Radeon RX 6600.txt");
                    await bot.SendDocumentAsync(message.Chat.Id, file);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
        static async Task SendFile2(TelegramBotClient bot, Message message)
        {
            var info = new DirectoryInfo(@"C:\Data\model\60000-70000\");
            try
            {
                FileInfo[] fileInfoGroup = info.GetFiles();
                foreach (var fileInfo in fileInfoGroup)
                {
                    var fileStream = new FileStream(fileInfo.FullName, FileMode.Open);
                    var file = new InputOnlineFile(fileStream, "PALIT NVIDIA GeForce GTX 1660TI.txt");
                    await bot.SendDocumentAsync(message.Chat.Id, file);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
        static async Task SendFile3(TelegramBotClient bot, Message message)
        {
            var info = new DirectoryInfo(@"C:\Data\miner\60000-70000\");
            try
            {
                FileInfo[] fileInfoGroup = info.GetFiles();
                foreach (var fileInfo in fileInfoGroup)
                {
                    var fileStream = new FileStream(fileInfo.FullName, FileMode.Open);
                    var file = new InputOnlineFile(fileStream, "PALIT NVIDIA GeForce GTX 1660TI.txt");
                    await bot.SendDocumentAsync(message.Chat.Id, file);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}
