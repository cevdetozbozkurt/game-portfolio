# Yayın ve geliştirme

Canlı adres: **https://cevdetozbozkurt.github.io/game-portfolio/**

Bu uygulama Blazor **WebAssembly standalone** olarak çalışır. C# kodları .NET çalışma ortamıyla birlikte ziyaretçinin tarayıcısına indirilir. GitHub Pages yalnızca ortaya çıkan statik dosyaları sunar. Sunucu kirası, API anahtarı veya kredi kartı gerekmez; depo herkese açık kalmalıdır.

## Güncelleme

1. İçerik: `src/ErenPortfolio/Data/PortfolioContent.cs`.
2. Bölümler: `src/ErenPortfolio/Pages/Home.razor`.
3. Yetenek ağacı: `src/ErenPortfolio/Components/SkillTree.razor`.
4. Tasarım: `src/ErenPortfolio/wwwroot/css/app.css`.
5. Mini oyun: `Components/PixelWorld.razor` ve `Models/ExplorationState.cs`.
6. `master` dalına push yapıldığında GitHub Actions kontrolleri çalıştırır, projeyi derler ve Pages'e yükler. Pull request'lerde yalnızca doğrulama yapılır.

## Doğrulama

```sh
dotnet run --project tests/Portfolio.Checks
dotnet publish src/ErenPortfolio -c Release -o artifacts/publish
python scripts/prepare-pages.py artifacts/publish/wwwroot --base /game-portfolio/
```

Son komut yalnızca yayın çıktısındaki base yolunu değiştirir; kaynak `index.html` yerel geliştirme için `/` kullanır. Sayfa içi bağlantılar `#projects` gibi fragment kullanır. Eksik bir adrese gidilirse geri dönüş bağlantısı olan özel 404 sayfası gösterilir.

Derlemeden sonra çalışan yerel sunucuyu yeniden başlatın; .NET statik dosya manifesti ve parmak izleri değişebilir.

## Tercihler ve gizlilik

Ses varsayılan olarak kapalıdır ve yalnızca mini oyundan açılır. İşletim sisteminin azaltılmış hareket tercihi desteklenir. Üst menüden hareketleri durdurma tercihi tarayıcının yerel depolamasına kaydedilir; depolama kapalıysa o oturum için çalışır. Form veya mesaj sunucusu yoktur: e-posta bağlantıları kullanıcının e-posta uygulamasını açar. Analytics veya izleme yoktur.

## Daha sonra sunucu eklemek

ASP.NET Core Web API, PostgreSQL/EF Core ve yönetim paneli ayrı bir sunucu gerektirir. Mevcut C# veri modelleri ve Blazor arayüzü kullanılmaya devam edebilir; içerik daha sonra API üzerinden alınabilir. Sunucu sırları veya özel anahtarlar WebAssembly uygulamasına eklenmemelidir.

## Eski sürüm

İlk HTML/CSS çalışması `docs/original-prototype/` altında ve Git geçmişinde korunur. Canlı site yalnızca `src/ErenPortfolio` projesinden oluşturulur.
