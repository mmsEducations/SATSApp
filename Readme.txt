Proje Businessý : Bu proje ne yapar kapasamý ve amacaý nedir? 
Öðrenci yoklama sistemi :Amaaç öðrenciler'in girdikleri yada giremdeikleri dersin listesini oluþturma
Kulanýlan Mimari : Katmanlý mimari 
Circular Dependency

Kullanýlan Kütüphaneler 
-ORM
 -EntityFrameworkCore
 -EntityFrameworkCore.Relational
 -EntityFrameworkCore.Tools
-Database
 -EntityFrameworkCore.PostgreSQL

-Validasyon
 FluentValidation
 Girilen verileri,requestleri validate etmek içim ullanýlýr,Merkezi doðrulama,kolay test edilebilir,hata mesjalrýný özelleþtirme

-MediatR-CORS(Command Query Responsibility)
  MediatoR Datnet kütüphaneleri için kullanýlýp Cors ve mediator tasarým deseninin uygulamaya yarar
  Sýnýflar arasýnda baðýmlýlýðý azaltýp,bileþenler arasý iletiþimi merkezi bir mekanizma aracýlýðýyle yönetmemizi saðlar
  CORS
  Command : Veri tabanýnda deðiþklikik yapan iþlemler 
  Query   : Veri tabanýndan okuma yapan iþlemler


-Swagger Dökümantasyon
 Swashbuckle-swagger entegrasyonu için 

-Authentication(Kimlik doðrulama)
 JWTBearer Token
 Authentication.JwtBearer

 -Authentication-Kimlik doðrulama-Sisteme giren kiþinin kim olduðunu belirleme süreci
 Kulllanýcý adý ve parola ile sisteme girenin kim olduðuna karar veriyorum
 Kontrol ettiðimiz      metod -sign-in
 Kullanýcý adý(eposta) ve þifre verme -sing-up(Register,kaydetme):sistemi kullanacaklara kullanýcý ade ve þifre belirleme metodu
  Authorization 
   -Normal Authorization : email ve password ile giriþ
   -2FA(iki faktörlü kimlik doðrulama) Notmal Authorizationa ek olarak bir code bilgisi ile(öreneðim emal'e yada Telefona'a gelen) kimlik doðrulama yapýlabilir

Authantication Yöntemleri 
 Kullanýcý adý ve þifre
 Biometrik doðrulama(parmak izi,yüz tanýma)
 2FA-Two Factor

 -Authorization(Yetkilendirme)
  Kimliði doðrulanan kullanýcý hangi kaynkalara(endointlere) eriþecek bunu belirleme iþlemdir
  Kullancýnýn sahip olduðu roller ve izinlerin yönetilmesidir
  Kullanýcý sisteme girdikten sonra sadece kendi mesajlarýný görebilir,diðer kullanýcýlara gelen mesajlarý göremez
  Sisteme kullanýcý ekleme(register,sign up) ,silme iþleminin belirlik kiþilerde olmasý 

  Authorization Yönetmleri 
  -Role-Base Authorization 
   -Rollere eriþebileceði yetkiler tanýmlanýr,Kullanýcýlarada roller atanýr 
   Role-admin
   Role-basic
   tuðçe-basic
   esra-admin
   1)Role tanýmla
   2)Role yetki verme
   3)Kullanýcýnýn role baðlanmasý
  -Plicy-based Authorization 
   kullanýcýnýn belirli özellik veya durumuna göre izin beirleme,sadece kadýnlar bu iþlemleri yapsýn
  -Claim-based Authorization kullanýcýnýn belirli taleplerine göre izinler tanýmlanýr 
   Departman bazlý yetki düzenleme 

-Ardalis.Specification
-Ardalis.Specification.EntityFrameworkCore
 
-Ardalis.Specification 
  Bir specification Pattern uygulamasýdýr,Belirli bir kriteri karþýlayan nesneleri tanýmlayan yeniden kullanýlabilir ve test edilebilir sýnýflar
  Yeniden kullanýlabilirlik,Test edilebilme,kod tekrarýný azaltma

-Ardalis.Specification.EntityFrameworkCore
 Ardalis kütüphanesini Enity Framework Core ile entegre eder.Bu Entegrasyon EF ile çalýþan veri eirþim katmanlarýnda Specification'ý kullanmamýzý saðlar

 -Mapper
  AutoMapper
  AutoMapper.Extensions.Microsoft.DependencyInjection

  AutoMapper :Nesneler arasý dönüþüm yapmayý kolaylaþtýrmak için kullanýlýr,AutoMapper verilen nesnler arasýnda 
  otamatik bir þekilde dönüþüm yapar ve manuel mapping'e göre kod daha temiz ve düzenli olur

  DTOs :Veri taþýyan nesneler 
  Entity to DTOs
  ----------------------------------------------------
 -Microsoft.AspNetCore.Identity
  Microsoft.AspNetCore.Identity.EntityFrameworkCore

  Microsft Identity Implementation Adýmlarý 
  1)Dbcontext deðiþikliði
  2)program.cs deðiþikliði
  ---- 
  1-
  class SATSAppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
     base.OnModelCreating(modelBuilder); //ZORUNLU : Kullanýcý tablolarýnýn otomatik oluþmasý için önemli
     modelBuilder.RenameIntityConfigurationTables(); //Rename Creating Identity Tables 
  }
  2-
  //Identity management entegration 
  builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SATSAppDbContext>().AddDefaultTokenProviders();

  ----------------------------------------------------

Proje Katmanlarý 
1)Business 
  Asýl mantýksal,iþlemlerin yapýldýðý iþ katmaný diye anýlan katmandýr.
  MadiatR-Cors
  -Cors
    Command :Create,Update,Delete
        public class XCommand : IRequest<XResponse>
    Queries :Read clasý
        public class XQuery : IRequest<XResponse>
  -MadiatR
   Handlers
      Asýl iþ katmanýdýr 
         public class XHandler : IRequestHandler<XCommand/XQuery, XResponse>
   Presentation katmanýndaki controller üzerinden Yayýnlanan-çaðrýlan metod handler içierisinde yakalanýr,handle edilir
   
   -Repositories
    EFCORESpecification'ýn bize sunduðu repositoryler'in tanýmlandýðý
    interface IXEntityRepository : IRepositoryBase<XEntity>
    class XEntityRepository : RepositoryBase<XEntity>, IXEntityRepository

  -Specifications
   -sql sorgularý'ný c# nesnesi(class'ý) olarak yazma iþi
   
    public class SpecNameSpec : Specification<XEntity>
    {
        public SpecNameSpec()
        {
            Query
                 .Where(x => x.IsDeleted == false)
                 .AsNoTracking();
        }
    }
  -Validations 
   Kullanýcýdan parametre alan endpointlerin kontrollerinin yapýldýðý yer  
   Kullanýcý inputlarýnýn kontrol edildiði yer 

  -Ardalist Guard 
   Kodun belirli koþullarý saðladýðýný kontrol etmek içi kullanýlýr 
   Koruma ve güvenlik saðlýyor 

   Test Senaryolarý
   Happy path - iyi seneryo test etme
   Bad   path - kötü(hatalý parametre yada veri tipleri ,verilerle) senaryo test etme
   

   Object Reference Error

2)Data 
  - IEntityTypeConfiguration
    Modellerin-entitiylerin yapýlandýrýlmasý iþlemi 
    Bizim belirlediðimiz modele göre veritabaný þemasý tablosu ve tablo kolonlarý ve koln veri tipleri oluþturur
    Configurasyon ayarlarýna göre tablo oluþtur(kolon adý,tipi,iliþkiler..)
    1)Configurasyonu entity bzlý oluþtur 
    2)Configurasyonu OnModelCreating() metodunda çaðýrarak uygula
 -Entity
   Veri tabanýndaki tablolarýn object olarak c# karþýlýðý 
-Context 
   Dbde oluþak tablolaraýn ayarlanmasý ..configurasyonlarýn ,veri tabaný connection ayarlarýnýn set edildiði ana yapi
-Migrations
   Db'deki her bir migration, deðiþiklik burada tutulur(dosya bazlý)
3)Presentation
  -Controllers
   Herbir endpoint dönüþ tipleri ile birlikte yazýlýr 
   Mümkün mertepe endpint içerisine business kod'u yazmýyoruz

   get,post,put ...atributu
   dönüþtipleri 
   dönüþ kodlarý-200,400,...
   medot adý -> GetCourses fakat dýþarýya açtýðýmýz ismi deðiþtrebiliriz 
   metod adý deðiþtirme : [HttpGet("courses")]
   Örneðin:
   
    [HttpGet]--
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<Course>>> GetCourses()
    {
        var students = await _mediator.Send(new GetCoursesQuery());
        return Ok(students);
    }

 -appsettings.json
  Program ayarlarnýn belirledniði yer 
  -Configurasyon veri tabaný baðlantýlarý ,rabbitmq redesi baðlantý bilgileri ,email gönderim 
  -Appsettings üzerinde tutualn azý özellikleri program içeriisnde kullanýrsak yazýlan kodlarý 
   deðiþtirmeden uygulaya deðiþiklik yapabilme kabiliyeti vermiþ oluyorum 
-Program.cs
   Projedeki ana yapýlarýn Injectionlarýn yönetilip pipeline oluþturulup ayaða kalktýðý yer 


   ----------------------------------------------------------------------------------------------------------------
   AutoMapper Example 
   public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            //Source -> Destination
            CreateMap<Course, CourseDto>();
        }
    }

      public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.ListAsync(new GetCourseListReadOnlySpec(), cancellationToken);

            return _mapper.Map<List<CourseDto>>(courses); //map 'Course' to CourseDto
        }
    }
    ----------------------------------------------------------------------------------------------------------------

    Roller 
    Admin 
    ViewUser
    EditUser


    --Instance alma yöntemleri 
  --1
  public static async Task SeedRoles(IServiceProvider serviceProvider)
  {
        var roleManager = serviceProvider.GetRequiredService<UserManager<IdentityRole>>();
  }

  --2
   private readonly UserManager<IdentityUser> _userManager;
   public SignInQueryHandler(UserManager<IdentityUser> userManager)
   {
        _userManager = userManager;
   }

   Not:
   Herhangi bir c# dosaysýnda appsettins.json'a eriþmek için IConfiguration kullanýlmalýdýr
   ----------------------------------------------------------------------------------------------------------------

   RabbitMQ    :  Open SOurce,Message Broker ,Mesalarý kuyruklayan bir mesajlaþma sistemidir 
                  Uygulamalar arasýnda asenkron mesaj alýþveriþini saðlamak için kullanýlýr.
    
    -(Kuyruk)Mesajlar kuruklar üzerinden iletilir-alýcýlar bu kuyruða baðlanarak mesajlarý okur 

    -(Asenkron)Asenkron çalýþýr :Mesajlar anýnda iþlenmek zorunda deðildir,Kuyruða alýndaýktan sonra uygun alýcýlar mesaj aldýðýnda iþlenir 
    -(Daðýtýk sistem)Daðýtýk sistemlerde kullanýma uygundur:Sistemler arasý 
    Advance Message Queuing Protool(AMQP) bu yapýya göre çalýþýr 

   Masstransit : .Net kütüphanesidir ,uygulamalar arasý mesajlaþmayý yönetmek için kullanýlan bir mesajlaþma orkestrator'üdür 
                Farklý mesajlaþma altyapýlarýana(RabbitMQ,Azure Servise Bus,Amazon SQS,Active MQ) kolayca entegre olup ,mesaj gönderme ve alma iþlemini basitleþtiren kütüphanedir.

    -(Mesaj alýþveriþi)Mesaj alýþveriþini basitleþtirir: Mesaj gönderme ,Kuruklama yönlendirme ,alma gibi iþlemleri kolaylaþtýran bir kütüphane
    -(Farklý mesajlaþma altyapýsý) Farklý mesajlaþma altyapýlarýný destekler :  RabbitMQ,Azure Service Bus,Active MQ gibi mesajlaþma yapýlarýyla etegre çalýþýr
    -(Kolay Ölçeklenebilirlik) Mikroservis mimarilerinde yaygýn olarak kullanýlýr.
    -Publisher-Consumer yapýsýný destekler

    Özetle : Mesaj altyapýlarýný kullanýmýmýzý kolaylaþtýran yapý.

    Neden Message queue Mekanizmasý kullanýlýr:

    Ýmplementation Adýmlarý 
    Kütüphaneler 
    <PackageReference Include="MassTransit" Version="8.2.5" />
    <PackageReference Include="MassTransit.RabbitMQ" Version="8.2.5" />


    1)EventModel oluþturulmasý
    2)Consumer edilmesi 
    3)Publish edilmesi


  1)EventModel oluþturulmasý
       public class CreateStudentCommandEventModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    2)Consumer edilmesi 
        public class CreateStudentCommandConsumer : IConsumer<CreateStudentCommandEventModel>
    {
        public Task Consume(ConsumeContext<CreateStudentCommandEventModel> context)
        {
            var message = context.Message;
            Console.WriteLine($"{DateTime.Now} tarihinde {message.FirstName + " " + message.LastName} verisi gelmiþtir");

            return Task.CompletedTask;
        }
    }