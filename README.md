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
---

## 📊 Ekran Görüntüleri ve Proje Akışları

### 🎓 Eğitim ve Başarı
<details>
<summary><b>Sertifikayı Görmek İçin Tıklayın</b></summary>
<br>
> Projenin temelini oluşturan eğitim sürecinin tamamlandığına dair sertifika.

<img width="100%" alt="Kurs Sertifikası" src="https://github.com/user-attachments/assets/b1694964-7856-4b12-b00b-6b8add409cf9" />
</details>

---

### 🏠 Kullanıcı Arayüzü (WebUI) - Ana Sayfa
<details>
<summary><b>Ana Sayfa Görsellerini Görmek İçin Tıklayın</b></summary>
<br>
> Ziyaretçileri karşılayan modern, dinamik ve kurumsal slider yapısına sahip ana sayfa vitrini.

<img width="100%" alt="Ana Sayfa 1" src="https://github.com/user-attachments/assets/c7c289f5-ffc1-4969-86e7-c30be41fac31" />
<img width="100%" alt="Ana Sayfa 2" src="https://github.com/user-attachments/assets/edbdfdca-6f01-49e9-9248-4c4cfc387214" />
<img width="100%" alt="Ana Sayfa 3" src="https://github.com/user-attachments/assets/843cd7a6-ec0c-4d56-aa79-d4486f9c8433" />
<img width="100%" alt="Ana Sayfa 4" src="https://github.com/user-attachments/assets/daad6610-8d9d-41ee-9df5-40dc588a3726" />
<img width="100%" alt="Ana Sayfa 5" src="https://github.com/user-attachments/assets/407328e4-5609-4d5b-9b70-ee186499f993" />
<img width="100%" alt="Ana Sayfa Footer" src="https://github.com/user-attachments/assets/aa677552-347a-493c-b37e-dbaae0ae6c8d" />
</details>

---

### 📂 Proje Portföyü ve Filtreleme
<details>
<summary><b>Filtreleme Görsellerini Görmek İçin Tıklayın</b></summary>
<br>
> Tamamlanan projelerin kategorilerine göre (Villalar, Ticari vb.) dinamik olarak filtrelenip listelendiği bölüm.

<img width="100%" alt="Kategori Filtreleme 1" src="https://github.com/user-attachments/assets/c663697c-5047-45a8-bcec-080d37905d6f" />
<img width="100%" alt="Kategori Filtreleme 2" src="https://github.com/user-attachments/assets/edc483e7-8561-4207-9e32-0c378745dec7" />
<img width="100%" alt="Kategori Filtreleme 3" src="https://github.com/user-attachments/assets/83abe0c2-1fba-4850-b273-aa5d0e42f6b3" />
<img width="100%" alt="Kategori Filtreleme 4" src="https://github.com/user-attachments/assets/c2807375-86d5-48e7-90ba-569722de23eb" />
<img width="100%" alt="Kategori Filtreleme 5" src="https://github.com/user-attachments/assets/5e201acd-9e13-4440-bdc8-49c19ce8345a" />
</details>

---

### 📅 Randevu Yönetim Sistemi ve Gmail Entegrasyonu
<details>
<summary><b>Randevu Süreci ve Mail Bildirimlerini Görmek İçin Tıklayın</b></summary>
<br>
> Kullanıcının randevu talep etme süreci ve bu talebin onay/red durumunun Gmail SMTP üzerinden kullanıcıya anlık bildirilmesi akışı.

<img width="100%" alt="Randevu Alma Formu" src="https://github.com/user-attachments/assets/bd8807fc-f148-401d-b0c1-0ad0b9d81796" />
<img width="100%" alt="Randevu Takvimi Seçimi" src="https://github.com/user-attachments/assets/1fd540fc-d173-456b-a270-eb251b468b7c" />
<img width="100%" alt="Randevu Detayları" src="https://github.com/user-attachments/assets/bbf053d7-9c29-4a6c-97c0-72ba0800bd4c" />
<img width="100%" alt="Randevu Başarılı" src="https://github.com/user-attachments/assets/5b10ef8a-e4b5-471e-afb6-2481f9ac73a5" />
<img width="100%" alt="Admin Randevu Paneli" src="https://github.com/user-attachments/assets/64a01bb9-4052-479b-af6b-6d8b16cdde0a" />

> **✉️ Gmail SMTP Bildirimi:** Admin onayından sonra kullanıcıya giden e-posta örneği.
<img width="100%" alt="Gmail Bildirim Örneği" src="https://github.com/user-attachments/assets/2c98b867-1abd-4b4a-98eb-93772f53f64b" />
</details>

---

### 🤖 Gemini AI - Akıllı Fizibilite ve Parsel Sorgulama
<details>
<summary><b>Yapay Zeka Analiz Ekranlarını ve PDF Çıktısını Görmek İçin Tıklayın</b></summary>
<br>
> Projenin en inovatif kısmı: Kullanıcının haritadan konum seçip isteklerini belirttiği, Gemini Pro'nun ise inşaat maliyeti, deprem riski ve imar durumunu analiz ettiği süreç.

<img width="100%" alt="AI Konum Seçimi" src="https://github.com/user-attachments/assets/56939340-ec00-46cf-be48-c644126df1a7" />
<img width="100%" alt="AI İstek Girişi" src="https://github.com/user-attachments/assets/86db697c-a01b-4935-ab84-3c790ba08bea" />
<img width="100%" alt="AI Analiz Süreci 1" src="https://github.com/user-attachments/assets/295e501d-4f06-432f-8b5d-b9689b13a62c" />
<img width="100%" alt="AI Analiz Süreci 2" src="https://github.com/user-attachments/assets/fed6350b-3fb6-4396-8941-d0cbaeacfcf6" />
<img width="100%" alt="AI Sonuç Ekranı 1" src="https://github.com/user-attachments/assets/31d363c0-1d95-498d-8ccf-0959878a53b0" />
<img width="100%" alt="AI Sonuç Ekranı 2" src="https://github.com/user-attachments/assets/c13109ce-1df1-437b-8d24-e2b864d624a4" />

> **📄 Oluşturulan PDF Raporu:** Yapay zeka analizinin indirilebilir PDF çıktısı.
<img width="100%" alt="AI PDF Çıktısı Önizleme" src="https://github.com/user-attachments/assets/164b3ef6-fd4f-4516-9720-6589a4d17496" />

📖 **[Örnek Yapay Zeka Fizibilite Raporunu (PDF) İndirin](https://github.com/user-attachments/files/27203903/Arkitektur_Fizibilite_Raporu.1.pdf)**
</details>

---

### 🔑 Kimlik Doğrulama (Identity & JWT)
<details>
<summary><b>Kayıt Ol ve Giriş Yap Ekranlarını Görmek İçin Tıklayın</b></summary>
<br>
> Güvenli kayıt olma, giriş yapma ve yetkilendirme süreçleri.

**📝 Kayıt Ol Ekranı**
<img width="100%" alt="Kayıt Ol 1" src="https://github.com/user-attachments/assets/dda60ec5-8aff-41d4-90fd-a73dffe87515" />
<img width="100%" alt="Kayıt Ol 2" src="https://github.com/user-attachments/assets/679950fc-d734-4380-88fc-77c231be88f6" />
<img width="100%" alt="Kayıt Ol 3" src="https://github.com/user-attachments/assets/18ce0202-8161-4495-9ce4-b7d3222febf6" />
<img width="100%" alt="Kayıt Ol 4" src="https://github.com/user-attachments/assets/24bd7503-459c-4779-bdc9-1d98d187432e" />

**🔓 Giriş Yap Ekranı**
<img width="100%" alt="Giriş Yap 1" src="https://github.com/user-attachments/assets/62e5ffad-20e9-41a1-9674-19d60691abac" />
<img width="100%" alt="Giriş Yap 2" src="https://github.com/user-attachments/assets/aef01f31-21db-43c5-88f0-8475d4bae12f" />
</details>

---

### 🛠️ Admin Yönetim Paneli
<details>
<summary><b>Admin Paneli Görsellerini Görmek İçin Tıklayın</b></summary>
<br>
> Sistem içerisindeki tüm dinamik verilerin (Projeler, Randevular, Ekip, Mesajlar vb.) yönetildiği kapsamlı kontrol paneli.

<img width="100%" alt="Admin Panel Dashboard" src="https://github.com/user-attachments/assets/222f71dd-2fee-4f81-8f44-3de03e286b0b" />
<img width="100%" alt="Admin Proje Yönetimi 1" src="https://github.com/user-attachments/assets/e0f3300f-cc04-417e-adde-ce3916c6917d" />
<img width="100%" alt="Admin Proje Yönetimi 2" src="https://github.com/user-attachments/assets/0de5178a-c84a-4700-a6f7-74375b0585c8" />
<img width="100%" alt="Admin Kategori Yönetimi" src="https://github.com/user-attachments/assets/8c8750a0-ce82-467d-af80-9b4a7510bfc9" />
<img width="100%" alt="Admin Randevu Yönetimi" src="https://github.com/user-attachments/assets/1bedaa23-2d95-4d99-a009-189343d34f47" />
<img width="100%" alt="Admin Ekip Yönetimi 1" src="https://github.com/user-attachments/assets/7225a934-bdfa-47bb-a8b8-148c189014b0" />
<img width="100%" alt="Admin Ekip Yönetimi 2" src="https://github.com/user-attachments/assets/88802646-3d4e-4d65-9dc2-8a11ba710371" />
<img width="100%" alt="Admin Ekip Yönetimi 3" src="https://github.com/user-attachments/assets/8011ac72-f8d3-4e84-ad8d-3f666e5e80f5" />
<img width="100%" alt="Admin Referans Yönetimi" src="https://github.com/user-attachments/assets/c145ae95-fee7-4df7-a916-46f7dcec7eb9" />
<img width="100%" alt="Admin Mesaj Yönetimi 1" src="https://github.com/user-attachments/assets/b634681a-5545-41dc-801a-912cd433c61b" />
<img width="100%" alt="Admin Mesaj Yönetimi 2" src="https://github.com/user-attachments/assets/9495b8c4-0b83-4650-b8f7-c913d2736dd2" />
<img width="100%" alt="Admin Ayarlar 1" src="https://github.com/user-attachments/assets/23937d62-d11b-4052-8248-d7db9c3dfb9b" />
<img width="100%" alt="Admin Ayarlar 2" src="https://github.com/user-attachments/assets/df3bdb37-105d-44c5-9f2e-cd2ac6b1b76c" />
<img width="100%" alt="Admin Ayarlar 3" src="https://github.com/user-attachments/assets/ad29e332-fb81-4501-bc99-bdbe656dcf8d" />
<img width="100%" alt="Admin Profil 1" src="https://github.com/user-attachments/assets/5b585516-ebfd-4a37-9143-31529f788c82" />
<img width="100%" alt="Admin Profil 2" src="https://github.com/user-attachments/assets/b5db356d-2fcd-441f-a63a-4af61c429441" />
<img width="100%" alt="Admin Profil 3" src="https://github.com/user-attachments/assets/3c2da66c-96c7-40ff-a267-3efd259f5d6b" />
<img width="100%" alt="Admin Login" src="https://github.com/user-attachments/assets/32f33ed3-d6e1-4033-a843-68689756858f" />
</details>

---

### 📡 API Dokümantasyonu (Scalar)
<details>
<summary><b>API Arayüzünü Görmek İçin Tıklayın</b></summary>
<br>
> Projenin API katmanının Scalar (Swagger alternatifi) üzerinden dokümante edilmiş hali.

<img width="100%" alt="API Scalar Dokümantasyonu" src="https://github.com/user-attachments/assets/eb125d5f-edc3-478d-bb71-bb51ba98ac30" />
</details>

---

### 🏗️ Solution ve Katman Yapısı
<details>
<summary><b>Mimari Katman Dosyalarını Görmek İçin Tıklayın</b></summary>
<br>
> Projenin N-Katmanlı Mimari (N-Layer Architecture) prensiplerine göre fiziksel klasörlenmesi.

<img width="100%" alt="Solution Yapısı Genel" src="https://github.com/user-attachments/assets/7fee45ed-e0ce-41b3-a956-47280e5ff669" />
<img width="100%" alt="DataAccess Katmanı" src="https://github.com/user-attachments/assets/66d47348-6fed-4abf-b15c-7df58087d728" />
<img width="100%" alt="Business Katmanı" src="https://github.com/user-attachments/assets/b96da80b-ba3a-48ec-be58-6051c6011f1f" />
<img width="100%" alt="API Katmanı" src="https://github.com/user-attachments/assets/4c545519-acd8-4ea2-a054-44b0820371b0" />
<img width="100%" alt="WebUI Katmanı" src="https://github.com/user-attachments/assets/30631e11-aa5c-4817-a9be-3f4695122ee1" />
</details>


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
