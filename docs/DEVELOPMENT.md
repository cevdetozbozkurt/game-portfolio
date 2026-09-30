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

Projeler ve filtre kategorileri `src/ErenPortfolio/Data/PortfolioContent.cs` dosyasındadır. Kaynaklar: mevcut portfolyo, paylaşılan çalışma planı, kullanıcının CV'si ve herkese açık GitHub proje sayfaları. Bilinmeyen iş tarihleri, proje sonuçları ve bağlantılar uydurulmaz. Gerçek oyun/uygulama görüntüleri ilgili proje depolarından alınır; konsept çizimler ayrıca etiketlenir. `scripts/generate-project-art.py` CV projelerinin özgün SVG konsept görsellerini yeniden üretir.

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

Mini oyun sınırları, kristal toplama, yeniden başlatma, proje filtreleri, galeri verileri, arşiv notları, düzeltilen CV bağlantısı ve yayın görselleri için 28 otomatik kontrol vardır. Masaüstü ve mobil tarayıcıda filtreler, detay penceresi, galeri, klavye kontrolleri, menü, yetenek ağacı ve taşma kontrol edilir.

Site bir kişisel oyun ve öğrenme arşividir; ticari hizmet veya iş teklifi çağrısı içermez. Kütüphanede 19 proje bulunur: yedi oyun, üç yapay zekâ/veri projesi, üç web/bulut projesi ve altı deney. Oyunlar ilk açılışta seçilidir; tüm projelere filtrelerden ulaşılır. Kaynağı bulunamayan AR Room Scanner ve bulut kampı projesi, bağlantı paylaşılmayan RAG ve eğitim oyunu ayrı açıklamalı kayıtlarla gösterilir. Gelecekte yapılabilecek yeni bir AR prototipi mevcut projenin yerine tamamlanmış gibi gösterilmez. CV'deki Python alıştırmaları bağlantısı doğrulanan doğru depoya yönlendirilir; çelişkili proje tarihleri yayımlanmaz.

İlk HTML/CSS çalışmanız `docs/original-prototype/` altında ve Git geçmişinde saklanır.
