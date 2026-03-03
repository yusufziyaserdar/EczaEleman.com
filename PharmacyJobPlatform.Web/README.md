# EczaEleman.com

EczaEleman.com is a role-based ASP.NET Core MVC application that helps pharmacy owners and pharmacy professionals find each other, communicate, and complete hiring workflows in one place.

Instead of acting like a basic listing board, the platform brings together:
- profile management,
- job posting and application flows,
- real-time messaging,
- rating/comment features,
- and admin moderation tools.

## English

### What the platform includes

#### Worker side
- Account registration and login
- Editable personal profile
- CV upload and work-experience entries
- Job search and filtering
- Applying to open pharmacy positions
- Tracking own applications
- Viewing and managing conversation requests/messages
- Rating and commenting on pharmacy owner profiles

#### Pharmacy owner side
- Account registration with pharmacy details
- Creating, updating, activating/deactivating job posts
- Reviewing incoming applications
- Access to conversation and messaging features
- Rating workers after interactions

#### Admin side
- Dashboard overview
- Handling user reports and moderation actions

### Technical stack
- .NET 8
- ASP.NET Core MVC
- Entity Framework Core + SQL Server
- SignalR (chat hub)
- Cookie-based authentication/authorization
- BCrypt.Net (password hashing)

### Solution structure
```text
PharmacyJobPlatform.Web/
├── PharmacyJobPlatform.Web.sln
├── PharmacyJobPlatform.Web/              # MVC app (controllers, views, web assets)
├── PharmacyJobPlatform.Infrastructure/   # DbContext, migrations, seed/data services
└── PharmacyJobPlatform.Domain/           # Core entities and enums
```

### Quick start
1. **Clone and open the solution folder**
   ```bash
   git clone <repo-url>
   cd pharmacy-job-platform/PharmacyJobPlatform.Web
   ```
2. **Restore and build**
   ```bash
   dotnet restore
   dotnet build PharmacyJobPlatform.Web.sln
   ```
3. **Create local configuration**
   - Add `appsettings.json` in `PharmacyJobPlatform.Web/PharmacyJobPlatform.Web/`
   - Optionally add `appsettings.Development.json`
   - Put your own values for database, email, and map api keys
4. **Run database migrations** (optional if auto-migrate is enabled)
   ```bash
   dotnet ef database update --project PharmacyJobPlatform.Infrastructure --startup-project PharmacyJobPlatform.Web
   ```
5. **Run the app**
   ```bash
   dotnet run --project PharmacyJobPlatform.Web
   ```

### License
This project is distributed under the **MIT License**. See the `LICENSE` file.

---

## Türkçe

EczaEleman.com , eczane sahipleri ile eczane alanında çalışan profesyonelleri tek bir platformda buluşturmak için geliştirilmiş, rol bazlı bir ASP.NET Core MVC uygulamasıdır.

Sadece bir ilan sitesi gibi çalışmak yerine; profil yönetimi, başvuru süreci, mesajlaşma, puanlama/yorumlama ve admin moderasyon akışlarını birlikte sunar.

### Platformda neler var?

#### Çalışan (Worker) tarafı
- Kayıt olma ve giriş
- Profil düzenleme
- CV yükleme ve iş deneyimi ekleme
- İş ilanlarını listeleme/filtreleme
- İlanlara başvuru yapma
- Kendi başvurularını takip etme
- Konuşma istekleri ve mesajlaşma ekranları
- Eczane sahibi profillerine puan ve yorum bırakma

#### Eczane sahibi (PharmacyOwner) tarafı
- Eczane bilgileriyle kayıt
- İlan oluşturma, güncelleme, aktif/pasif etme
- Gelen başvuruları görüntüleme
- Mesajlaşma ve iletişim akışları
- Etkileşim sonrası çalışanları puanlama

#### Admin tarafı
- Yönetim paneli
- Rapor/moderasyon süreçleri

### Teknik yapı
- .NET 8
- ASP.NET Core MVC
- Entity Framework Core + SQL Server
- SignalR (chat hub)
- Cookie tabanlı kimlik doğrulama/yetkilendirme
- BCrypt.Net (şifre hashleme)

### Proje yapısı
```text
PharmacyJobPlatform.Web/
├── PharmacyJobPlatform.Web.sln
├── PharmacyJobPlatform.Web/              # MVC uygulaması
├── PharmacyJobPlatform.Infrastructure/   # Veritabanı ve migration katmanı
└── PharmacyJobPlatform.Domain/           # Entity ve enum tanımları
```

### Hızlı kurulum
1. **Projeyi klonla ve klasöre gir**
   ```bash
   git clone <repo-url>
   cd pharmacy-job-platform/PharmacyJobPlatform.Web
   ```
2. **Paketleri geri yükle ve build al**
   ```bash
   dotnet restore
   dotnet build PharmacyJobPlatform.Web.sln
   ```
3. **Yerel ayar dosyalarını oluştur**
   - `PharmacyJobPlatform.Web/PharmacyJobPlatform.Web/` altında `appsettings.json` oluştur
   - Gerekirse `appsettings.Development.json` ekle
   - Veritabanı, e-posta ve harita anahtarlarını kendi ortamına göre gir
4. **Migration çalıştır** (otomatik migration yoksa)
   ```bash
   dotnet ef database update --project PharmacyJobPlatform.Infrastructure --startup-project PharmacyJobPlatform.Web
   ```
5. **Uygulamayı başlat**
   ```bash
   dotnet run --project PharmacyJobPlatform.Web
   ```


### Lisans
Bu proje **MIT License** ile lisanslanmıştır. Detay için `LICENSE` dosyasına bakabilirsin.
