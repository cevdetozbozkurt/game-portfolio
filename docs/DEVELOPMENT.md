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

Mini oyun, filtreler, galeriler, arşiv bilgileri ve GitHub commit servisi için 50 otomatik kontrol vardır. Commit kontrolleri gerçek GitHub'a istek atmaz; yenilenen mesajı, çok satırlı açıklamaları, boş depoyu, hatalı yanıtları, istek sınırını, çevrimdışı durumu, zaman aşımını ve iptali sahte HTTP yanıtlarıyla doğrular. Masaüstü ve mobil tarayıcıda görünüm ve gerçek GitHub bağlantısı ayrıca kontrol edilir.

Site bir kişisel oyun ve öğrenme arşividir; ticari hizmet veya iş teklifi çağrısı içermez. Kütüphanede 20 proje bulunur: oyunlar sekmesinde devam eden Unity Learn günlüğü dahil sekiz çalışma, üç yapay zekâ/veri projesi, üç web/bulut projesi ve altı deney. Oyunlar ilk açılışta seçilidir; tüm projelere filtrelerden ulaşılır. Kaynağı bulunamayan AR Room Scanner ve bulut kampı projesi, bağlantı paylaşılmayan RAG ve eğitim oyunu ayrı açıklamalı kayıtlarla gösterilir. Gelecekte yapılabilecek yeni bir AR prototipi mevcut projenin yerine tamamlanmış gibi gösterilmez. CV'deki Python alıştırmaları bağlantısı doğrulanan doğru depoya yönlendirilir; çelişkili proje tarihleri yayımlanmaz.

## Canlı Unity Learn commit bilgisi

`Unity Learn Journal` detayları her açıldığında ve `Refresh` düğmesine basıldığında, tarayıcı `https://api.github.com/repos/cevdetozbozkurt/UnityLearn/commits?per_page=1` adresinden varsayılan dalın son commit'ini ister. Diğer projeler ve ilk sayfa yüklemesi commit isteği yapmaz. Arka planda periyodik sorgulama yoktur. Yeni commit'ler için portfolyonun yeniden yayımlanması gerekmez.

C# servisi `Services/GitHubCommitService.cs`, görünümü `Components/LatestCommit.razor` dosyasındadır. Proje açılışında bileşen yeni anahtarla oluşturulur; önceki isteği iptal edilir. Tarayıcı fetch seçenekleri `no-store` ve `omit` kullanır. Kimlik bilgisi, token veya ücretli sunucu gerekmez. GitHub'ın kendi yanıt önbelleği kısa süreli gecikmeye neden olabilir; panel kontrol saatini UTC olarak gösterir.

İstek sekiz saniyede zaman aşımına uğrar. Erişim/limit/ağ sorunu olduğunda açıklama ve GitHub bağlantısı çalışmaya devam eder. Bu oturumda daha önce başarılı bir yanıt alındıysa yalnızca bellekte tutulan son commit, eski veri olduğu ve son yüklenme zamanı belirtilerek gösterilir. Başarılı yanıt önbellekten sunulmaz; her açılış yeni istek başlatır. Ham HTML veya Markdown çalıştırılmaz; mesaj metni Razor tarafından kodlanır. Commit bağlantısı doğrulanan SHA ve sabit GitHub alan adından oluşturulur.

GitHub herkese açık, kimlik doğrulamasız REST erişimini IP başına sınırlar (uygulama sırasında 60 istek/saat). Bu sınır ziyaretçinin aynı IP üzerinden yaptığı diğer API çağrılarıyla paylaşılır. Token'ı istemci koduna eklemek yerine gerektiğinde ziyaretçi commit geçmişine yönlendirilir. Kaynak: https://docs.github.com/en/rest/using-the-rest-api/rate-limits-for-the-rest-api.

İlk HTML/CSS çalışmanız `docs/original-prototype/` altında ve Git geçmişinde saklanır.
