using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SATSApp.Data.Entities;

namespace SATSApp.Data.Extensions
{
    public static class ModelBuilderSeedDataCreaterExtensions
    {

        public static void CreateSeedData(this ModelBuilder modelBuilder)
        {
            var dummyStudents = CreateDummyStudentData();
            modelBuilder.Entity<Student>().HasData(dummyStudents);

            var dummyCourses = CreateDummyCourseData();
            modelBuilder.Entity<Course>().HasData(dummyCourses);

            //Burdan Role yada User ekleme işlemleri yapılabilir
            modelBuilder.Entity<IdentityRole>().HasData(
              new IdentityRole { Id = "4", Name = "TestRole", NormalizedName = "TESTROLE" }
           );
        }

        private static List<Student> CreateDummyStudentData()
        {
            var students = new List<Student>();
            var random = new Random();
            var names = GetNames();
            var lastNames = GetSurnames();
            var cities = GetCities();

            var name = "";
            var lastName = "";
            var city = "";

            for (int i = 1; i <= 20; i++)
            {
                name = names[random.Next(names.Length)];
                lastName = lastNames[random.Next(lastNames.Length)];
                city = cities[random.Next(cities.Length)];
                students.Add(new Student
                {
                    StudentId = i,
                    FirstName = name,
                    LastName = lastName,
                    BirthDate = DateTime.UtcNow.AddDays(-i * 365), // yaklaşık doğum tarihi
                    Email = $"{name}{lastName}@example.com",
                    City = city,
                    CreaDate = DateTime.UtcNow
                });
            }
            return students;
        }

        private static List<Course> CreateDummyCourseData()
        {
            var courses = new List<Course>();
            for (int i = 1; i <= 2; i++)
            {
                courses.Add(new Course
                {
                    CourseId = i,
                    CourseName = $"Ozz Akademi{i}",
                    CourseDescription = $"Description for Course{i}",
                    CreaDate = DateTime.UtcNow
                });
            }
            return courses;
        }

        static string[] GetNames()
        {
            string[] turkishNames = new string[]
            {
            "İsmail", "Muhammed", "Halid", "Elif", "Abbas", "Zeynep", "Hasan", "Fatma", "İsmail", "Emine",
            "Mustafa", "Hatice", "Murat", "Aylin", "Orhan", "Sevgi", "Kemal", "Özlem", "Can", "Nur",
            "Haluk", "Sibel", "Hakan", "Derya", "Ömer", "Meryem", "Burak", "Selin", "Serkan", "Aysel",
            "Gül", "Tolga", "Büşra", "Yasin", "İpek", "Arda", "Cengiz", "Hülya", "Engin", "Vildan",
            "Barış", "Pinar", "Kadir", "Nazlı", "Ebru", "Emre", "Şirin", "Sinan", "Ceren", "Caner",
            "Nihan", "Yavuz", "Esra", "Alper", "Gamze", "Cem", "Özgül", "İbrahim", "Gülçin", "Volkan"
            };

            return turkishNames;
        }

        static string[] GetSurnames()
        {
            string[] turkishSurnames = new string[]
            {
            "Yılmaz", "Kaya", "Demir", "Çelik", "Yurt", "Kurt", "Arslan", "Koç", "Aydın", "Yalçın",
            "Akman", "Kara", "Duman", "Çakır", "Kara", "Gündüz", "Özkan", "Aksu", "Gül", "Çetin",
            "Erdoğan", "Çetin", "Acar", "Toprak", "Karaoğlu", "Uysal", "Kara", "Kaya", "Erdem",
            "Yavuz", "Kaya", "Ekinci", "Akkaya", "Çakmak", "Karaca", "Arı", "Özdemir", "Ege", "Bozkurt"
            };

            return turkishSurnames;
        }

        static string[] GetCities()
        {
            string[] turkishCities = new string[]
            {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın",
            "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa",
            "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum",
            "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir",
            "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis",
            "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde",
            "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Şanlıurfa", "Şırnak",
            "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak", "Aksaray",
            "Bayburt", "Karabük", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karaman", "Kırıkkale", "Osmaniye", "Düzce"
            };

            return turkishCities;
        }

    }
}
