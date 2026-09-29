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
