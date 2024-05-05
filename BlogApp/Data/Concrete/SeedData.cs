

using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama", Url = "web-programlama", Color = TagColors.warning},
                        new Tag { Text = "backend", Url = "backend", Color = TagColors.info},
                        new Tag { Text = "frontend", Url = "frontend", Color = TagColors.success},
                        new Tag { Text = "fullstack", Url = "fullstack", Color = TagColors.secondary},
                        new Tag { Text = "php", Url = "php", Color = TagColors.primary}                        
                    );

                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "furkansari", Name="Furkan Sarı", Email="f.s@qwe.com", Password="123", Image = "p1.jpg" },
                        new User { UserName = "ahmetyilmaz", Name="Ahmet Yılmaz", Email="a.y@qwe.com", Password="1234", Image = "p2.jpg" }
                    );

                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post {
                            Title ="Asp.net core",
                            Description ="Asp.net core",
                            Content = @"ASP.NET, Microsoft tarafından geliştirilmiş olan bir açık kaynak Web uygulama gelişimi teknolojisidir. Dinamik Web sayfaları, Web uygulamaları ve XML tabanlı Web hizmetleri geliştirilmesine olanak sağlar. Aynı işletme tarafından geliştirilen .NET çatısı'nın yazılım iskeleti parçası ve artık işletmece desteklenmeyen ASP teknolojisinin devamını teşkil etmiştir.

                            Her ne kadar isim benzerliği olsa da ASP.NET, ASP'ye oranla çok ciddî bir değişim geçirmiştir. ASP.NET kodu ortak dil çalışma zamanı (İngilizce: Common Language Runtime) altyapısına dayalı olarak yazılımcılar tarafından .NET çatısı tarafından desteklenen tüm dilleri ASP.NET uygulamaları geliştirmek için kullanabilirler. Yani Java teknolojisinde olduğu gibi yazılımcı tarafından yazılan kod, çalıştırılmadan önce sanal bir yazılım katmanı tarafından ortak bir dile çevirilmekte olup bu katmanın yerleştirildiği bütün işletim sistemlerinde çalışabilmektedir.",
                            Url ="aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1        ,
                            Comments=new List<Comment>{ 
                                new Comment{Text = "İyi bir kurs", PublishedOn = DateTime.Now.AddHours(-10), UserId = 2},
                                new Comment{Text = "Teşekkürler", PublishedOn = DateTime.Now.AddHours(-3), UserId = 1}
                            }                   
                         },
                         new Post {
                            Title ="Php",
                            Description ="Php",
                            Content = @"PHP, yazılım geliştiriciler için oldukça popüler olan, web tabanlı, HTML içine gömülebilen, nesne yönelimli bir programlama dilidir. E-ticaret sitelerinden CRM sistemlerine kadar kullanılabilen genel amaçlı bir dildir.

                            PHP sunucu taraflı iletişimler için yaratılmıştır. JavaScript gibi kullanıcı tarafında çalışan dillerden bu özelliği ile ayırılır. JavaScript hem frontend ve hem de backend için kullanılır. 

                            Web geliştiriciler için önemli bir konuma sahip olan PHP, form verisi toplamak, görüntüleri değiştirmek, veri tabanlarını düzenlemek vb. gibi çeşitli sunucu taraflı fonksiyonları yapar. Web sitelerinin içeriklerinin yönetildiği paneli kullanabilmemizi sağlar. Yani web sitelerinin çalışmasının arkasında gizli görev alan araçlardan biridir. ",
                            Url ="php",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.jpg",
                            UserId = 1                           
                         },
                         new Post {
                            Title ="Djyango",
                            Description ="Djyango",
                            Content = @"Django, web uygulamalarını hızlı ve verimli bir şekilde geliştirmek için kullanabileceğiniz bir yazılımdır. Çoğu web uygulaması; kimlik doğrulama, bir veri tabanından bilgi alma ve çerez yönetimi gibi birkaç ortak işleve sahiptir. Geliştiriciler, yazdıkları her web uygulamasına benzer işlevleri kodlamalıdır. Django, farklı işlevleri web uygulaması çerçevesi olarak adlandırılan geniş bir yeniden kullanılabilir modül koleksiyonunda gruplandırarak işlerini kolaylaştırır. Geliştiriciler, kodlarını daha verimli bir şekilde düzenlemek, yazmak ve web geliştirme süresini önemli ölçüde azaltmak için Django web çerçevesini kullanır.",
                            Url ="djyango",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2                     
                         },
                         new Post {
                            Title ="React Dersleri",
                            Description ="React Dersleri",
                            Content = @"ReactJS, geliştiriciler tarafından web uygulamaları için kullanıcı arayüzleri oluşturmak amacıyla kullanılan güçlü bir JavaScript kütüphanesidir. İlk olarak 2011 yılında Facebook tarafından web sitelerinin performansını artırmak için oluşturuldu ve o zamandan beri dünya çapındaki geliştiriciler tarafından yaygın bir şekilde benimsendi. React JS'nin en önemli avantajlarından biri, tüm sayfayı yeniden yüklemeye gerek kalmadan kullanıcı arayüzünü verimli bir şekilde güncellemesine olanak tanıyan sanal DOM'udur. Ayrıca React JS, karmaşık kod tabanlarını basitleştirmeye ve geliştirmeyi daha hızlı ve verimli hale getirmeye yardımcı olabilecek yeniden kullanılabilir bileşenler oluşturmayı kolaylaştırır.",
                            Url ="react",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "4.jpg",
                            UserId = 1                     
                         },
                         new Post {
                            Title ="Angular",
                            Description ="Angular",
                            Content = @"Angular, Google tarafından geliştirilen ve desteklenen SPA(Single Page Application) uygulama yapılmasına olanak sağlayan javascript kütüphanesidir.

                            Angular model view controller yapısına bağlı geliştirme yapabilirsiniz. Eğer .net developersanız ve MVC yapısını kullandıysanız Angular’ a daha kolay hakim olabilirsiniz. Bu konudaki öğrenme süreciniz oldukça hızlı olacaktır.",
                            Url ="angular",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "5.jpg",
                            UserId = 1                     
                         },
                         new Post {
                            Title ="Web Tasarım",
                            Description ="Web Tasarım",
                            Content = @"İnternet tarayıcıların görüntülenmesi özel olarak hazırlanan bir tasarım olan web tasarımı, HTML dilinde olarak uzmanlar tarafında yapılmaktadır. Bunu yapan kişilere web master veya web tasarımcısı denilmektedir. Kısaca tasarım fikirlerini bir estetik çizgide belli bir amaçlar dâhilinde yönlendirdiği ve düzenliği bunlarında uygulamaya dönüşmesi işlemidir. Bütün bu işlemlerin tamamlanmasıyla aktif bir web sitesi ortaya çıkar. Web tasarımı uygulamasından sonra kullanıcılar bir web sitesi tarayıcısı ile internet üzerinde web sitelerine erişmektedir.",
                            Url ="web-tasarim",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-60),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "6.jpg",
                            UserId = 1                     
                         }
                    );
                    context.SaveChanges();
                }

            }
        }
    }
}