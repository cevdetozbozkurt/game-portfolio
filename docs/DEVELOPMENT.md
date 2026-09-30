# Eren.dev — Game Developer Portfolio

Cevdet Eren Özbozkurt'un pixel art temalı kişisel portfolyosu.

## Teknoloji ve ücretsiz yayın

- **C# / .NET 10 / Blazor WebAssembly**: arayüz, proje filtreleri ve mini oyun tarayıcıda çalışır.
- **GitHub Pages**: herkese açık bu depo için ücretsiz statik barındırma.
- **CSS + SVG**: responsive tasarım, özgün pixel çizimler ve hareketler.
- Küçük bir JavaScript modülü yalnızca tarayıcı özellikleri için kullanılır.
- Sunucu, veritabanı, ücretli hizmet veya API anahtarı gerekmez.

## Yerelde çalıştırma

```sh
dotnet run --project src/ErenPortfolio --urls http://localhost:5180
```

.NET 10 SDK gerekir. `http://localhost:5180` adresini açın.

## İçerik

Projeler `src/ErenPortfolio/Data/PortfolioContent.cs` dosyasındadır. Kaynaklar: mevcut portfolyo, paylaşılan çalışma planı ve herkese açık GitHub proje README'leri. Bilinmeyen iş tarihleri, proje sonuçları ve bağlantılar uydurulmaz. Gerçek oyun görüntüleri ilgili proje depolarından alınır; konsept çizimler ayrıca etiketlenir.

## Sonraki aşama

GitHub Pages ASP.NET Core sunucusu veya veritabanı çalıştırmaz. Daha sonra aynı Blazor arayüzüne ASP.NET Core Web API, EF Core/PostgreSQL ve kimlik doğrulamalı yönetim paneli eklenebilir. Bu sürüm çalışan bir C# projesidir; C#'a yeniden yazılması gerekmez.

## Canlı site ve yayın

[Portfolyoyu aç](https://cevdetozbozkurt.github.io/game-portfolio/)

`master` dalına gönderilen her değişiklik GitHub Actions ile otomatik doğrulanıp yayımlanır. Kurulum ve içerik güncelleme bilgileri: [docs/DEPLOYMENT.md](DEPLOYMENT.md). Kaynaklar ve font lisansları: [docs/CONTENT-SOURCES.md](CONTENT-SOURCES.md).

## Kontroller

```sh
dotnet run --project tests/Portfolio.Checks
dotnet publish src/ErenPortfolio -c Release -o artifacts/publish
```

Mini oyun sınırları, kristal toplama, yeniden başlatma, proje filtreleri, galeri verileri ve yayın görselleri için 21 otomatik kontrol vardır. Masaüstü ve mobil tarayıcıda filtreler, detay penceresi, galeri, klavye kontrolleri, menü, yetenek ağacı ve taşma kontrol edilir.

Site bir kişisel oyun ve öğrenme arşividir; ticari hizmet veya iş teklifi çağrısı içermez. Kütüphanede altı oyun/prototip ve iki deney bulunur. Kaynağı bulunamayan AR Room Scanner geçmiş çalışma olarak etiketlenmiştir. Gelecekte yapılabilecek yeni bir AR prototipi mevcut projenin yerine tamamlanmış gibi gösterilmez.

İlk HTML/CSS çalışmanız `docs/original-prototype/` altında ve Git geçmişinde saklanır.
