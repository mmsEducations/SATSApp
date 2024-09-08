Proje Business� : Bu proje ne yapar kapasam� ve amaca� nedir? 
��renci yoklama sistemi :Amaa� ��renciler'in girdikleri yada giremdeikleri dersin listesini olu�turma
Kulan�lan Mimari : Katmanl� mimari 
Circular Dependency

Kullan�lan K�t�phaneler 
-ORM
 -EntityFrameworkCore
 -EntityFrameworkCore.Relational
 -EntityFrameworkCore.Tools
-Database
 -EntityFrameworkCore.PostgreSQL

-Validasyon
 FluentValidation
 Girilen verileri,requestleri validate etmek i�im ullan�l�r,Merkezi do�rulama,kolay test edilebilir,hata mesjalr�n� �zelle�tirme

-MediatR-CORS(Command Query Responsibility)
  MediatoR Datnet k�t�phaneleri i�in kullan�l�p Cors ve mediator tasar�m deseninin uygulamaya yarar
  S�n�flar aras�nda ba��ml�l��� azalt�p,bile�enler aras� ileti�imi merkezi bir mekanizma arac�l���yle y�netmemizi sa�lar
  CORS
  Command : Veri taban�nda de�i�klikik yapan i�lemler 
  Query   : Veri taban�ndan okuma yapan i�lemler


-Swagger D�k�mantasyon
 Swashbuckle-swagger entegrasyonu i�in 

-Authentication(Kimlik do�rulama)
 JWTBearer Token
 Authentication.JwtBearer

 -Authentication-Kimlik do�rulama-Sisteme giren ki�inin kim oldu�unu belirleme s�reci
 Kulllan�c� ad� ve parola ile sisteme girenin kim oldu�una karar veriyorum
 Kontrol etti�imiz      metod -sign-in
 Kullan�c� ad�(eposta) ve �ifre verme -sing-up(Register,kaydetme):sistemi kullanacaklara kullan�c� ade ve �ifre belirleme metodu
  Authorization 
   -Normal Authorization : email ve password ile giri�
   -2FA(iki fakt�rl� kimlik do�rulama) Notmal Authorizationa ek olarak bir code bilgisi ile(�rene�im emal'e yada Telefona'a gelen) kimlik do�rulama yap�labilir

Authantication Y�ntemleri 
 Kullan�c� ad� ve �ifre
 Biometrik do�rulama(parmak izi,y�z tan�ma)
 2FA-Two Factor

 -Authorization(Yetkilendirme)
  Kimli�i do�rulanan kullan�c� hangi kaynkalara(endointlere) eri�ecek bunu belirleme i�lemdir
  Kullanc�n�n sahip oldu�u roller ve izinlerin y�netilmesidir
  Kullan�c� sisteme girdikten sonra sadece kendi mesajlar�n� g�rebilir,di�er kullan�c�lara gelen mesajlar� g�remez
  Sisteme kullan�c� ekleme(register,sign up) ,silme i�leminin belirlik ki�ilerde olmas� 

  Authorization Y�netmleri 
  -Role-Base Authorization 
   -Rollere eri�ebilece�i yetkiler tan�mlan�r,Kullan�c�larada roller atan�r 
   Role-admin
   Role-basic
   tu��e-basic
   esra-admin
   1)Role tan�mla
   2)Role yetki verme
   3)Kullan�c�n�n role ba�lanmas�
  -Plicy-based Authorization 
   kullan�c�n�n belirli �zellik veya durumuna g�re izin beirleme,sadece kad�nlar bu i�lemleri yaps�n
  -Claim-based Authorization kullan�c�n�n belirli taleplerine g�re izinler tan�mlan�r 
   Departman bazl� yetki d�zenleme 

-Ardalis.Specification
-Ardalis.Specification.EntityFrameworkCore
 
-Ardalis.Specification 
  Bir specification Pattern uygulamas�d�r,Belirli bir kriteri kar��layan nesneleri tan�mlayan yeniden kullan�labilir ve test edilebilir s�n�flar
  Yeniden kullan�labilirlik,Test edilebilme,kod tekrar�n� azaltma

-Ardalis.Specification.EntityFrameworkCore
 Ardalis k�t�phanesini Enity Framework Core ile entegre eder.Bu Entegrasyon EF ile �al��an veri eir�im katmanlar�nda Specification'� kullanmam�z� sa�lar

 -Mapper
  AutoMapper
  AutoMapper.Extensions.Microsoft.DependencyInjection

  AutoMapper :Nesneler aras� d�n���m yapmay� kolayla�t�rmak i�in kullan�l�r,AutoMapper verilen nesnler aras�nda 
  otamatik bir �ekilde d�n���m yapar ve manuel mapping'e g�re kod daha temiz ve d�zenli olur

  DTOs :Veri ta��yan nesneler 
  Entity to DTOs
  ----------------------------------------------------
 -Microsoft.AspNetCore.Identity
  Microsoft.AspNetCore.Identity.EntityFrameworkCore

  Microsft Identity Implementation Ad�mlar� 
  1)Dbcontext de�i�ikli�i
  2)program.cs de�i�ikli�i
  ---- 
  1-
  class SATSAppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
     base.OnModelCreating(modelBuilder); //ZORUNLU : Kullan�c� tablolar�n�n otomatik olu�mas� i�in �nemli
     modelBuilder.RenameIntityConfigurationTables(); //Rename Creating Identity Tables 
  }
  2-
  //Identity management entegration 
  builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SATSAppDbContext>().AddDefaultTokenProviders();

  ----------------------------------------------------

Proje Katmanlar� 
1)Business 
  As�l mant�ksal,i�lemlerin yap�ld��� i� katman� diye an�lan katmand�r.
  MadiatR-Cors
  -Cors
    Command :Create,Update,Delete
        public class XCommand : IRequest<XResponse>
    Queries :Read clas�
        public class XQuery : IRequest<XResponse>
  -MadiatR
   Handlers
      As�l i� katman�d�r 
         public class XHandler : IRequestHandler<XCommand/XQuery, XResponse>
   Presentation katman�ndaki controller �zerinden Yay�nlanan-�a�r�lan metod handler i�ierisinde yakalan�r,handle edilir
   
   -Repositories
    EFCORESpecification'�n bize sundu�u repositoryler'in tan�mland���
    interface IXEntityRepository : IRepositoryBase<XEntity>
    class XEntityRepository : RepositoryBase<XEntity>, IXEntityRepository

  -Specifications
   -sql sorgular�'n� c# nesnesi(class'�) olarak yazma i�i
   
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
   Kullan�c�dan parametre alan endpointlerin kontrollerinin yap�ld��� yer  
   Kullan�c� inputlar�n�n kontrol edildi�i yer 

  -Ardalist Guard 
   Kodun belirli ko�ullar� sa�lad���n� kontrol etmek i�i kullan�l�r 
   Koruma ve g�venlik sa�l�yor 

   Test Senaryolar�
   Happy path - iyi seneryo test etme
   Bad   path - k�t�(hatal� parametre yada veri tipleri ,verilerle) senaryo test etme
   

   Object Reference Error

2)Data 
  - IEntityTypeConfiguration
    Modellerin-entitiylerin yap�land�r�lmas� i�lemi 
    Bizim belirledi�imiz modele g�re veritaban� �emas� tablosu ve tablo kolonlar� ve koln veri tipleri olu�turur
    Configurasyon ayarlar�na g�re tablo olu�tur(kolon ad�,tipi,ili�kiler..)
    1)Configurasyonu entity bzl� olu�tur 
    2)Configurasyonu OnModelCreating() metodunda �a��rarak uygula
 -Entity
   Veri taban�ndaki tablolar�n object olarak c# kar��l��� 
-Context 
   Dbde olu�ak tablolara�n ayarlanmas� ..configurasyonlar�n ,veri taban� connection ayarlar�n�n set edildi�i ana yapi
-Migrations
   Db'deki her bir migration, de�i�iklik burada tutulur(dosya bazl�)
3)Presentation
  -Controllers
   Herbir endpoint d�n�� tipleri ile birlikte yaz�l�r 
   M�mk�n mertepe endpint i�erisine business kod'u yazm�yoruz

   get,post,put ...atributu
   d�n��tipleri 
   d�n�� kodlar�-200,400,...
   medot ad� -> GetCourses fakat d��ar�ya a�t���m�z ismi de�i�trebiliriz 
   metod ad� de�i�tirme : [HttpGet("courses")]
   �rne�in:
   
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
  Program ayarlarn�n belirledni�i yer 
  -Configurasyon veri taban� ba�lant�lar� ,rabbitmq redesi ba�lant� bilgileri ,email g�nderim 
  -Appsettings �zerinde tutualn az� �zellikleri program i�eriisnde kullan�rsak yaz�lan kodlar� 
   de�i�tirmeden uygulaya de�i�iklik yapabilme kabiliyeti vermi� oluyorum 
-Program.cs
   Projedeki ana yap�lar�n Injectionlar�n y�netilip pipeline olu�turulup aya�a kalkt��� yer 


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

    appsettings
