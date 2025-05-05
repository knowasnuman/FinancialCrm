# 💼 Financial CRM App

Bu proje, [Murat Yücedağ](https://www.udemy.com/user/murat-yucedag/) tarafından paylaşılan **C# Eğitim Kampı** serisinin son projesi olarak geliştirilmiş, MySQL destekli, Entity Framework ile entegre çalışan **Finansal CRM** uygulamasıdır.

## 🚀 Özellikler

### 🔐 Giriş & Kayıt Ekranı
- Yeni kullanıcı oluşturma ve mevcut kullanıcılarla giriş yapma desteği
- Basit ve kullanıcı dostu arayüz
/images/categories.png
/images/banks.png
/images/expenses.png
/images/invoices.png
/images/bank-transactions.png
/images/logout.png
![Login](images/signIn.png)
![Signup](images/signUp.png)

### 📊 Dashboard Paneli
- Toplam banka bakiyesi
- Elektrik, doğalgaz, su ve internet faturaları
- Son gelen banka hareketi
- Banka bakiyeleri için çubuk grafik
- Fatura türlerine göre pasta grafik

![Dashboard](images/dashboard.png)

### 🧭 Navigasyon
Sol taraftaki menü ile tüm sayfalara kolay erişim:
- **Kategoriler**
  - Harcama kategorilerini listeleme
  - Yeni kategori ekleme, silme, güncelleme
  - ID'ye göre kategori arama
  ![Kategoriler](images/categories.png)
- **Bankalar**
  - Banka bakiyelerini görme
  - Son 5 banka hareketini listeleme
  ![Bankalar](images/banks.png)  
- **Harcamalar**
  - Harcamaları listeleme
  - Yeni harcama ekleme, silme, güncelleme
  - ID’ye göre harcama arama
  ![Harcamalar](images/spendings.png)
- **Faturalar**
  - Fatura listesi
  - Yeni fatura ekleme, silme, güncelleme
  - ID’ye göre fatura arama
  ![Faturalar](images/bills.png)
- **Banka Hareketleri**
  - Tüm banka bakiyelerini ve hareketlerini listeleme
  ![Banka Hareketleri](images/bank-transactions.png)
- **Çıkış Yap** butonu ile oturumu sonlandırma
## 🛠️ Kullanılan Teknolojiler
- **C#** – Uygulama geliştirme dili
- **WinForms** – Masaüstü kullanıcı arayüzü
- **Entity Framework** – ORM yapısı
- **MySQL** – Veritabanı altyapısı

## 🗄️ Veritabanı
- Tüm veriler Entity Framework aracılığıyla MySQL veritabanına kaydedilir.
- Uygulama üzerinden eklenen her kayıt kalıcı olarak veritabanında tutulur.

## 📷 Ekran Görüntüleri
Görseller `/images` klasöründe yer almaktadır. Aşağıdaki örnekler:
- `login.png`
- `signup.png`
- `dashboard.png`

## 📦 Kurulum
1. Bu projeyi klonlayın:
   ```bash
   git clone https://github.com/kullaniciadi/financial-crm-app.git
