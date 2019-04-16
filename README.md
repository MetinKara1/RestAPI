# Dependency injection tasarım desenine uygun bir şekilde çeşitli kaynaklardan gelen dataları okumaya ve yönetmeye yönelik bir proje yapmaya çalıştım.

# Kullanılan teknolojiler ve programlama dilleri
- C#
- Rest Api
- Json
- Xml
- Excel
- Dependency Injection

# Kısa Açıklama: Data okuma classlarımız interface classımızı miras almaktadır ve okuyacağımız veri kaynağına göre ilgili classı newleyip url göndermemiz yeterli olacak şekilde dizayn edildi. Mesela excel okuyacağımız zaman Manager(new ReadExcel()) şeklinde yazmamız yeterli oluyor. Bu kullanımda projemizi daha uzun süreli ve değiştirmeden kullanabilmemizi sağlıyor. Bir müşterimiz ile bugün excel üzerinden çalışıyorken belli bir süre müşterimiz xml veya rest apiye geçiş yapmamızı isteyebilir. Bu durumda tüm kodları değiştirmek yerine kod içerisindeki bağımlıkları azaltarak daha küçük değişiklikler ile yeni yapılara geçişi hızlandırabiliriz. Projemde bu durumu örneklemeye çalıştım.
