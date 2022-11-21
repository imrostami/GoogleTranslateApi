<h1>کتابخانه استفاده از مترجم سایت گوگل (Google Translate) در زبان سی شارپ </h1>

به واسطه این کتابخونه خیلی راحت تر از اون چیزی که فک میکنید میتونید ترجمه رو به وسیله مترجم گوگل به داخل سی شارپ بیارید و ازش استفاده کنید 

روش استفاده به این شکله که 
اول یه نمونه از کلاس تنظیمات مترجم میسازیم


 ```csharp
    TranslatSetting setting = new TranslatSetting()
            {
                Content = "your text", //متنی که میخواید ترجمه کنید
                FromLanguage = LanguagesType.English, //زبان مبدا
                ToLanguage = LanguagesType.Persian //زبان مقصد
            
            };
 ```
 
 و بعد تنظیماتی که ایجاد کردیم رو به کار میگیریم
 
  ```csharp
    GoogleApi google = new GoogleApi();
    
     string tranlatedText = google.Translate(setting);
 ```
 
 برای اینکه بتونید متن ترجمه شده روببینید 
<code>tranlatedText</code>
رو چاپ کنید یا نشون بدید توی برنامتون


به همین راحتی !! :)
