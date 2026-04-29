<div align="center">

# 🏢 Arkitektur
### Yapay Zeka Destekli, Bulut Tabanlı Gayrimenkul ve İnşaat Analiz Platformu

![ASP.NET Core 9.0](https://img.shields.io/badge/ASP.NET_Core_9.0-5C2D91?style=for-the-badge&logo=dotnet)
![AWS](https://img.shields.io/badge/Cloud-Amazon_Web_Services-232F3E?style=for-the-badge&logo=amazonaws)
![Gemini Pro](https://img.shields.io/badge/AI-Google_Gemini_Pro-4285F4?style=for-the-badge&logo=google)
![JWT Auth](https://img.shields.io/badge/Security-JWT_%26_Identity-000000?style=for-the-badge&logo=jsonwebtokens)
![Architecture](https://img.shields.io/badge/Architecture-Clean_Code_%26_N--Layered-00C853?style=for-the-badge)

<br>

<p align="center">
  <strong>Gelişmiş Maliyet Analizi, Kesintisiz Bulut Depolama ve Merkezi Yönetim.</strong>
</p>
<p align="center">
  <i>Google Gemini Pro ile otonom arazi analizi, AWS S3 entegrasyonu, JWT tabanlı  mimarisi<br>ve Scrutor ile desteklenmiş best-practice bir .NET 9.0 API & MVC ekosistemi.</i>
</p>

</div>

---

**Arkitektur**, modern inşaat ve gayrimenkul dünyasının ihtiyaç duyduğu teknolojik dönüşümü (Cloud, AI, Architecture) tek bir çatı altında toplayan yenilikçi bir platformdur. Kullanıcıların harita üzerinden seçtikleri arazilerin yapay zeka ile saniyeler içinde analiz edildiği, tüm medya ve dosyaların **AWS (Amazon Web Services)** üzerinde güvenle depolandığı ve süreçlerin uçtan uca **Clean Code** prensipleriyle yönetildiği kurumsal bir çözümdür.

Bu proje, sadece bir web uygulaması değil; **best-practice** kodlama standartlarına sahip, ölçeklenebilir ve yüksek performanslı bir mimari referans modelidir.

---

## 🌟 Projenin 6 Ana Güç Sütunu

Arkitektur, standart bir yönetim panelinden öteye geçerek şu temel mühendislik harikalarıyla öne çıkar:

### 🧠 1. Gemini Pro ile Otonom Analiz ve Raporlama (GenAI)
Sistem, sadece veri kaydetmekle kalmaz, Google'ın en güçlü yapay zeka modellerinden biriyle entegre çalışarak otonom kararlar üretir.
* **Harita Tabanlı İstihbarat:** Kullanıcı haritadan bir arazi seçtiğinde, sistem o lokasyonun inşaat maliyetini, deprem riskini ve imar izni/arsa niteliği durumunu saniyeler içinde analiz eder.
* **Dinamik PDF Üretimi:** Yapay zeka tarafından çıkarılan detaylı maliyet ve risk analiz sonuçları, kullanıcıya anında profesyonel bir **PDF** raporu olarak sunulur ve indirilebilir.

### ☁️ 2. AWS ile Kesintisiz Bulut Entegrasyonu (Cloud Storage)
Geleneksel sunucu içi dosya saklama yöntemleri yerine, global standartlarda bulut mimarisi kullanılmıştır.
* **Merkezi Depolama:** Kullanıcıların ve yöneticilerin sisteme yüklediği görseller, belgeler ve proje dosyaları doğrudan **Amazon Web Services (AWS)** sunucularına aktarılır.
* **Hızlı Erişim:** Sistemdeki tüm medya dosyaları, sunucu yükünü hafifletmek adına doğrudan AWS linkleri üzerinden (`URL tabanlı`) frontend'e servis edilir.

### 🔐 3. JWT ve Identity ile Sıfır Güven (Zero Trust) Mimarisi
Kullanıcı güvenliği, modern web standartlarının en üst seviyesinde tutulmuştur.
* **Token Tabanlı İletişim:** Klasik oturum (session) yönetimi yerine, **JWT (JSON Web Token)** kullanılarak API ve MVC katmanları arasında tamamen stateless (durumsuz) ve güvenli bir iletişim köprüsü kurulmuştur.
* **ASP.NET Core Identity:** Kullanıcı rolleri, şifreleme ve yetkilendirme işlemleri Microsoft'un güçlü Identity kütüphanesi ile entegre bir şekilde yönetilir.

### 📬 4. Dinamik Randevu ve Otonom Bildirim Sistemi
Kullanıcı-Şirket etkileşimi tamamen dijitalleştirilmiş ve otomatize edilmiştir.
* **Talep Yönetimi:** Kullanıcılar sistem üzerinden şirket ile görüşmek için randevu talebi oluşturur.
* **Otonom Gmail Entegrasyonu:** Admin tarafından panele düşen bu randevular onaylandığında veya reddedildiğinde, arka planda çalışan servisler kullanıcıya **Gmail** üzerinden anında kurumsal bir bilgilendirme maili gönderir.

### 🛠️ 5. Özel Response Wrapper ve Interceptor Prensibi
API'nin dış dünya ile olan iletişimi tamamen standardize edilmiştir.
* **Custom Response Model:** API'den dönen hiçbir yanıt ham değildir. Tüm başarılı (Success), hatalı (Error) veya veri içeren (Data) dönüşler, projeye özel yazılmış *Wrapper* (Sarmalayıcı) sınıfları sayesinde standart bir JSON formatında istemciye iletilir.
* **Interceptor (AOP):** Metotların çalışmasından önce veya sonra devreye giren Interceptor yapıları ile loglama, validasyon gibi cross-cutting concerns (çapraz kesen ilgiler) iş mantığından izole edilmiştir.

### ⚙️ 6. Scrutor ile Auto-Registration (Otonom Bağımlılık Yönetimi)
Proje büyüdükçe artan karmaşıklık, akıllı kütüphanelerle çözülmüştür.
* **Temiz Program.cs:** Onlarca servisi (`AddScoped`, `AddTransient`) tek tek `Program.cs` dosyasına yazıp spagetti kod oluşturmak yerine, **Scrutor** kütüphanesi kullanılmıştır.
* **Otomatik Keşif:** Assembly içerisindeki arayüzler ve sınıflar otomatik olarak taranıp IoC Container'a kaydedilir, bu sayede yeni bir servis eklendiğinde kayıt işlemi manuel yapılmak zorunda kalınmaz.

### 🛡️ Otonom Veri Yaşam Döngüsü (AOP & Interceptors)
Veritabanı işlemleri geliştiricinin inisiyatifine bırakılmamıştır.
* **AuditDbContextInterceptor:** `BaseEntity`'den türeyen tüm tablolar izlenir. Veri eklendiğinde veya güncellendiğinde zaman damgaları (`CreatedAt`, `UpdatedAt`) araya girilerek (interception) otomatik basılır.
* **Smart Soft-Delete:** Veri fiziksel olarak silinmek istendiğinde, sistem bunu reddeder. Durumu `EntityState.Modified` olarak ezer ve `IsDeleted = true` yapar.
* **Global Query Filters:** `DbContext` seviyesinde uygulanan merkezi filtre ile, silinmiş veriler hiçbir LINQ sorgusuna (geliştirici unutsa bile) dahil edilmez.

### 📦 Standartlaştırılmış API İletişimi (Custom Wrapper)
API'nin dış dünya ile olan iletişimi tamamen disipline edilmiştir.
* Tüm endpointler `BaseResult<T>` sarmalayıcısı üzerinden yanıt döner. Başarılı veriler, hata mesajları, Identity hataları veya FluentValidation sonuçları daima standart bir JSON kalıbıyla (`Data`, `Errors`, `IsSuccessful`) istemciye ulaşır.

### 🧠 İstemci-API Köprüsü (TokenHandler & Exception Filters)
MVC ve API katmanları arasındaki iletişim tamamen otomatize edilmiştir.
* **Merkezi Token Yönetimi:** `HttpClientServices` içinde kurgulanan `TokenHandler` sayesinde, MVC tarafında API'ye atılan her isteğin HTTP Header'ına JWT otomatik olarak enjekte edilir.
* **Akıllı Hata Yakalama:** API'den fırlatılan validasyon hataları, MVC tarafında yazılan `ValidationExceptionFilter` ile havada yakalanır ve doğrudan `ModelState`'e basılarak kullanıcıya form üzerinde gösterilir. Spagetti `try-catch` bloklarına yer verilmemiştir.

### ⚙️ Yüksek Performans ve Otonomi
* **Bağımlılık Keşfi:** Onlarca repository ve service sınıfı `Program.cs`'e tek tek eklenmez. **Scrutor** kütüphanesi kullanılarak *Auto-Registration* (otomatik kayıt) mekanizması kurulmuştur.
* **Nesne Eşleme:** DTO-Entity dönüşümleri için yüksek performanslı **Mapster** kütüphanesi kullanılarak sistem hızı maksimize edilmiştir.


---

## 🏗️ Mimari ve Tasarım Prensipleri

Proje, birbirine sıkı sıkıya bağlı (tight coupling) yapılardan arındırılmış, **SOLID** prensiplerine sadık, **N-Katmanlı (N-Layered)** ve **Clean Architecture** (Temiz Mimari) felsefesiyle geliştirilmiştir.

| Katman / Konsept | Uygulama Detayı ve Teknolojiler |
| :--- | :--- |
| **Veri Erişim (DAL)** | **Entity Framework Core 9.0** |
| **Tasarım Deseni** | **Generic Repository & Unit of Work Pattern** |
| **İş Mantığı (BL)** | **Service Katmanı & FluentValidation** |
| **API Standartları** | **Custom Response Wrapper & Interceptors** |
| **Bağımlılık Yönetimi** | **Dependency Injection & Scrutor (Auto Registration)** |
| **Güvenlik & Yetkilendirme**| **ASP.NET Core Identity & JWT** |
| **Bulut Depolama** | **Amazon Web Services (AWS)** |
| **Yapay Zeka** | **Google Gemini Pro API** |
| **E-Posta Altyapısı** | **Gmail SMTP Entegrasyonu** |

---

### 🏛️ Mimari

Projede alınan her teknik karar, profesyonel bir yazılımın ihtiyaçlarına cevap vermek içindir:

#### 1. Generic Repository ve Unit of Work Deseni
* **Neden Generic Repository?** Her veritabanı tablosu için aynı CRUD işlemlerini tekrar tekrar yazmayı engeller (DRY Prensibi).
* **Neden Unit of Work?** Yapılan çoklu veritabanı işlemlerini (örneğin randevu onaylama ve log atma) tek bir *Transaction* içerisine alır. İşlem ortasında hata çıkarsa her şeyi geri alır (Rollback), başarılıysa tek seferde veritabanına yazar (Commit). Bu sayede veri tutarlılığı (%100) sağlanır.

#### 2. N-Katmanlı İzolasyon
* **Entity, Data Access, Business, API ve MVC** olmak üzere proje fiziksel olarak ayrılmıştır. API katmanı sadece dış dünyaya veri sunarken, iş kuralları (Business) ve veritabanı işlemleri (Data Access) birbirinden tamamen bağımsızdır. Bir katmandaki teknoloji değişimi, diğerini etkilemez.

#### 3. Custom Wrapper Mimarisi
* Front-end veya mobil geliştiricilerin API'yi tüketirken sürekli farklı JSON formatlarıyla karşılaşmasını önlemek için tüm API dönüşleri tek bir standarda (örneğin; `IsSuccess`, `Message`, `Data`, `Errors` alanlarını barındıran global bir modele) bağlanmıştır.

## 💎 Katmnalar
1. **Entity Layer:** Bağımlılıksız çekirdek katman (`BaseEntity`, Domain Modelleri).
2. **Data Access Layer:** Sadece veritabanı ile konuşan katman. **Generic Repository** ve **Unit of Work** tasarım desenleri ile işlem bütünlüğü (Transaction Integrity) güvence altına alınmıştır.
3. **Business Layer:** İş kurallarının, validasyonların ve AWS/SMTP entegrasyonlarının bulunduğu merkez. Mapster ile DTO dönüşümleri burada yapılır.
4. **API Layer:** Sadece istekleri karşılayan (Thin Controller) ve JWT kontrolü yapan sunum noktası.
5. **WebUI (MVC) Layer:** API'yi HttpClient ve TokenHandler mimarisiyle tüketen, filter yapısıyla exception'ları yöneten kullanıcı arayüzü.

## 🌟 Çekirdek Modüller ve Entegrasyonlar

| Modül | Entegrasyon | İşlevsellik Özeti |
| :--- | :--- | :--- |
| **Üretken Yapay Zeka** | **Google Gemini Pro** | Harita konumuna göre; inşaat maliyeti, deprem riski ve imar analizi yapıp, sonucu dinamik olarak **PDF** raporuna dönüştürür. |
| **Bulut Depolama** | **AWS S3 Bucket** | Sistemdeki tüm medya dosyaları sunucudan izole edilerek Amazon bulutunda depolanır ve doğrudan URL bazlı servis edilir. |
| **Yetkilendirme (Zero-Trust)** | **JWT & ASP.NET Identity** | Stateless mimari. Oturumlar sunucuda tutulmaz, şifreli JWT token'lar ve özelleştirilmiş (CustomErrorDescriber) Identity yapısıyla yönetilir. |
| **İletişim & Bildirim** | **Gmail SMTP** | Randevu talepleri admin tarafından onaylandığı veya reddedildiği an, asenkron olarak kullanıcıya kurumsal bilgilendirme e-postası fırlatılır. |
| **Veri Doğrulama** | **FluentValidation** | İş kuralları ve validasyonlar entity içinden ayrıştırılıp, `IValidator` arayüzleriyle tamamen izole bir katmanda yönetilir. |

## 📊 Ekran Görüntüleri

*(Projenin ekran görüntülerini veya GIF'lerini buraya ekleyebilirsiniz)*

## ⚙️ Kurulum

Projeyi yerel ortamınızda sorunsuz çalıştırmak için aşağıdaki adımları izleyin:

1.  **Projeyi Klonlayın**
    ```bash
    git clone [https://github.com/burakhanulusoy/Arkitektur_API.git](https://github.com/burakhanulusoy/Arkitektur_API.git)
    cd Arkitektur_API
    ```

2.  **Gerekli Ayarlamalar (appsettings.json)**
    API ve MVC projelerinizin `appsettings.json` dosyalarındaki şu alanları kendi bilgilerinizle güncelleyin:
    * **Connection Strings:** Kendi SQL veritabanı bağlantı cümleniz.
    * **AWS Configuration:** S3 Bucket ve Access/Secret Key bilgileriniz.
    * **Gemini AI:** Google Cloud üzerinden aldığınız API Key.
    * **JWT Ayarları:** Issuer, Audience ve Security Key bilgileriniz.
    * **Mail Ayarları:** Bildirimler için Gmail SMTP bilgileri.

3.  **Veritabanı Migrations**
    Package Manager Console üzerinden (Default Project: DataAccess seçili iken) veritabanını oluşturun:
    ```bash
    Update-Database
    ```

4.  **Projeyi Başlatın**
    Solution üzerinden API ve MVC projelerini `Multiple Startup Projects` olarak ayarlayın ve projeyi çalıştırın.

<div align="center">

## 🎥 Proje ve İletişim

Projenin mimari detayları üzerine konuşmak, iş birlikleri veya aklınıza takılan sorular için bana LinkedIn üzerinden ulaşabilirsiniz.

<a href="https://www.linkedin.com/in/burakhanulusoy/" target="_blank">
  <img src="https://img.shields.io/badge/LinkedIn-Burakhan%20Ulusoy-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" alt="LinkedIn Hesabım" />
</a>

<br>
<br>

📫 **Bana Ulaşın:** [linkedin.com/in/burakhanulusoy](https://www.linkedin.com/in/burakhanulusoy/)

</div>
