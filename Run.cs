using System;

namespace PhoneDirect
{
    public class Run
    {
        private Direct direct;
        private int option;

        public Run()
        {
            direct = new Direct();
            option = MainMenu();

            while (true)
            {
                switch (option)
                {
                    case 1:
                        AddNumber();
                        MainMenu();
                        break;
                    case 2:
                        DeleteNumber();
                        MainMenu();
                        break;
                    case 3:
                        UpdateNumber();
                        MainMenu();
                        break;
                    case 4:
                        GetAllNumbers();
                        MainMenu();
                        break;
                    case 5:
                        GetNumber();
                        MainMenu();
                        break;
                    default:
                        MainMenu();
                        break;
                }
            }
        }

        public int MainMenu()
        {
            Console.WriteLine("(1) Yeni numara ekle");
            Console.WriteLine("(2) Varolan numarayı sil");
            Console.WriteLine("(3) Varolan numarayı güncelle");
            Console.WriteLine("(4) Rehberi listele");
            Console.WriteLine("(5) Rehberde arama yap");
            Console.WriteLine("***********************************");
            Console.Write("Lütfen yapmak istediğiniz işlemi seçiniz: ");

            try
            {
                option = Convert.ToInt32(Console.ReadLine());
                if (option < 1 || option > 5) MainMenu();
            }
            catch (Exception)
            {
                MainMenu();
            }

            return option;
        }

        public void AddNumber()
        {
            Person person = new Person();

            Console.Write("Lütfen isim giriniz: ");
            person.FirstName = Console.ReadLine();

            Console.Write("Lütfen soyisim giriniz: ");
            person.LastName = Console.ReadLine();

            Console.Write("Lütfen telefon numarası giriniz: ");
            person.PhoneNumber = Console.ReadLine();

            direct.Add(person);
        }

        public void DeleteNumber()
        {
            Person person = new Person();

            Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ve soyadını giriniz: ");
            string FullName = Console.ReadLine();

            string[] name = FullName.Split(' ');
            person.FirstName = name[0];
            person.LastName = name[1];

            var result = direct.Get(person);

            if (result.Count > 0)
            {
                Console.Write(person.FirstName + " " + person.LastName + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");

                try
                {
                    char ch = Convert.ToChar(Console.ReadLine());
                    if (ch == 'y') direct.Delete(person);
                }
                catch (Exception)
                {
                    DeleteNumber();
                }
            }
            else
            {
                Console.WriteLine("(1) Silmeyi sonlandır");
                Console.WriteLine("(2) Yeniden dene");
                Console.WriteLine("*****************************************");
                Console.Write("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız: ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option < 1 || option > 2) MainMenu();
                }
                catch (Exception)
                {
                    MainMenu();
                }

                if (option == 1) return;

                DeleteNumber();
            }
        }

        public void UpdateNumber()
        {
            Person person = new Person();

            Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ve soyadını giriniz: ");
            string FullName = Console.ReadLine();

            string[] Name = FullName.Split(' ');
            person.FirstName = Name[0];
            person.LastName = Name[1];

            var result = direct.Get(person);

            if (result.Count > 0)
            {
                string key = person.FirstName + " " + person.LastName;
                person.PhoneNumber = result[key];

                Console.Write(person.FirstName + " isimli kişinin ismini değiştirmek istiyorsanız yeni ismini giriniz: ");
                string newFirstName = Console.ReadLine().TrimEnd();
                if (newFirstName is not null) person.FirstName = newFirstName;

                Console.Write(person.LastName + " soyisimli kişinin soyismini değiştirmek istiyorsanız yeni soyismini giriniz: ");
                string newLastName = Console.ReadLine().TrimEnd();
                if (newLastName is not null) person.LastName = newLastName;

                Console.Write(person.FirstName + " " + person.LastName + " isimli kişinin telefon numarasını değiştirmek istiyorsanız yeni telefon numarasını giriniz: ");
                string newPhoneNumber = Console.ReadLine().TrimEnd();
                if (newPhoneNumber is not null) person.PhoneNumber = newPhoneNumber;

                direct.Update(person);
            }
            else
            {
                Console.WriteLine("(1) Güncellemeyi sonlandır");
                Console.WriteLine("(2) Yeniden dene");
                Console.WriteLine("*****************************************");
                Console.Write("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız: ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option < 1 || option > 2) MainMenu();
                }
                catch (Exception)
                {
                    MainMenu();
                }

                if (option == 1) return;

                UpdateNumber();
            }
        }

        public void GetAllNumbers()
        {
            var result = direct.GetAll();

            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************");

            foreach (var item in result)
            {
                string[] Name = item.Key.Split(' ');
                Console.WriteLine("İsim: " + Name[0]);
                Console.WriteLine("Soyisim: " + Name[1]);
                Console.WriteLine("Telefon Numarası: " + item.Value);
                Console.WriteLine("-");
            }
        }

        public void GetNumber()
        {
            System.Console.WriteLine("(1) İsim ve soyisim ile arama");
            System.Console.WriteLine("(2) Telefon numarası ile arama");
            System.Console.WriteLine("*******************************");
            System.Console.Write("Arama yapmak istediğiniz tipi seçiniz: ");

            try
            {
                option = Convert.ToInt32(Console.ReadLine());
                if (option < 1 || option > 2) MainMenu();
            }
            catch (Exception)
            {
                MainMenu();
            }

            Person person = new Person();
            
            if (option == 1)
            {
                Console.Write("İsim ve soyisim giriniz: ");
                string FullName = Console.ReadLine();
                string[] Name = FullName.Split(' ');
                person.FirstName = Name[0];
                person.LastName = Name[1];
            }
            else
            {
                Console.Write("Telefon numarası giriniz: ");
                person.PhoneNumber = Console.ReadLine();
            }

            var result = direct.Get(person);

            Console.WriteLine("Arama sonuçlarınız");
            Console.WriteLine("******************************");

            foreach (var item in result)
            {
                string[] Name = item.Key.Split(' ');
                Console.WriteLine("İsim: " + Name[0]);
                Console.WriteLine("Soyisim: " + Name[1]);
                Console.WriteLine("Telefon Numarası: " + item.Value);
                Console.WriteLine("-");
            }
        }
    }
}
