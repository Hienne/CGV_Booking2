using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CGVBooking.Models;

namespace CGVBooking.DAL
{
    public class CGVIntializer : DropCreateDatabaseIfModelChanges<CGVDBContext>
    {
        public List<string> titleChair = new List<string>{ "A", "B", "C", "D", "E", "F", "G", "H", "J"};
        protected override void Seed(CGVDBContext context)
        {
            base.Seed(context);
            var users = new List<User>
            {
                new User{Name="Hien",PhoneNumber="035461", Password="1245", Email="hien@gmal.com", 
                        BirthOfDate=DateTime.Parse("2005-09-01"), Sex="nam", Balance = 100},
                new User{Name="Hi12",PhoneNumber="035423", Password="1245", Email="hien45@gmal.com", 
                        BirthOfDate=DateTime.Parse("2009-09-01"), Sex = "nam", Balance = 100}
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var chairs = new List<Chair>();
            for(int i = 0; i < titleChair.Count; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    if(i < 3)
                        chairs.Add(new Chair { Name = titleChair[i] + j.ToString(), Type = "Thường", Fare = 70, Status = false });
                    else
                        chairs.Add(new Chair { Name = titleChair[i] + j.ToString(), Type = "VIP", Fare = 75, Status = false });
                }
            }
            chairs.ForEach(c => context.Chairs.Add(c));
            context.SaveChanges();

            var films = new List<Film>
            {
                new Film { Name="Bloodshot", Director="Dave Wilson", Actor="Vin Diesel, Eiza González, Jóhannes Haukur Jóhannesson, Michael Sheen, Toby Kebbell",
                            Poster="bloodshot_cgv_1.jpg", Type="Hành động", Language="Tiếng Anh - Phụ đề Tiếng Việt",
                            Trailer="https://www.youtube.com/embed/6-T5-Tohan0", Rated="C18 - PHIM CẤM KHÁN GIẢ DƯỚI 18 TUỔI", Time=130,
                            PremiereDate=DateTime.Parse("2020-03-13"), Description="Ray Garrison là một sĩ quan cấp cao đã hy sinh trong một trận chiến. Thế nhưng, anh được tái sinh bằng công nghệ cao, " +
                            "giúp Ray sở hữu sức mạnh siêu nhiên và khả năng phục hồi nhanh chóng. Vận dụng những kỹ năng mới, anh săn lùng gã đàn ông đã giết vợ mình. " +
                            "Thế nhưng, khi sự thật dần hé mở, Ray nhận ra rằng không phải mọi thứ đều đáng tin. Ngay cả chính bản thân anh."},

                new Film { Name="Vì Anh Vẫn Tin", Director="Andrew Erwin, Jon Erwin", Actor="KJ Apa, Britt Robertson, Melissa Roxburgh, Shania Twain, Gary Sinise",
                            Poster="i-still-believe-1-poster-cgv_1.jpg", Type="Tình cảm", Language="Tiếng Anh - Phụ đề Tiếng Việt",
                            Trailer="https://www.youtube.com/embed/lidO3bXELzU", Rated="C13 - PHIM CẤM KHÁN GIẢ DƯỚI 13 TUỔI", Time=117,
                            PremiereDate=DateTime.Parse("2020-03-13"), Description="VÌ ANH VẪN TIN là bản tình ca ngọt ngào nhưng cũng thấm đượm nước " +
                            "mắt dựa trên cuốn hồi ký cùng tên của ca sĩ, nhạc sĩ người Mỹ Jeremy Camp. Phim kể về chính anh và Melissa Lynn Henning-Camp - " +
                            "người con gái mình yêu, người vợ và cũng là một trong những người có ảnh hưởng lớn nhất tới âm nhạc và cuộc đời của Jeremy từ lúc " +
                            "hai người gặp gỡ, kết hôn rồi đồng hành cùng nhau chiến đấu với căn bệnh ung thư đang dần cướp đi sinh mạng của Melissa."},

                new Film { Name="Kẻ Vô Hình", Director="Leigh Whannell", Actor="Elisabeth Moss, Oliver Jackson-Cohen, Storm Reid",
                            Poster="ke-vo-hinh-cgv_1.jpg", Type="Khoa Học Viễn Tưởng, Kinh Dị", Language="Tiếng Anh - Phụ đề Tiếng Việt",
                            Trailer="https://www.youtube.com/embed/pT3WbZmiZY4", Rated="C18 - PHIM CẤM KHÁN GIẢ DƯỚI 18 TUỔI", Time=127,
                            PremiereDate=DateTime.Parse("2020-02-28"), Description="Kẻ Vô Hình xoay quanh Cecilia Kass - cô gái bị mắc kẹt trong mối quan hệ đầy kiểm soát " +
                            "và bạo lực với khoa học gia tài năng và giàu có tên Adrian Griffin."},

                new Film { Name="Loạn Nhịp", Director="Jade Bunyoprakarn", Actor="Ken Theeradeth Wongpuapan, Manasaporn Chanchalerm",
                            Poster="loan-nhip_1.png", Type="Tình Cảm", Language="Tiếng Thái - Phụ đề Tiếng Việt",
                            Trailer="https://www.youtube.com/embed/evOeFZyYhzc", Rated="C16 - PHIM CẤM KHÁN GIẢ DƯỚI 16 TUỔI", Time=115,
                            PremiereDate=DateTime.Parse("2020-03-13"), Description="Điển trai, độc thân và kỹ lưỡng trong lối sống, Chai là hình tượng “sugar daddy” " +
                            "điển hình bên ngoài ấm áp bên trong trưởng thành. Cuộc gặp gỡ vô cùng bất ngờ và định mệnh với cô gái 9x - Whan đã khiến ông chú thập niên 90s " +
                            "thoát ra khỏi cuộc sống đơn sắc trước đây khi cả hai chợt nhận ra rằng, trái tim họ đang ngày càng loạn nhịp vì nhau."},

                new Film { Name="Nắng 3: Lời Hứa Của Cha", Director="Đồng Đăng Giao", Actor="Kiều Minh Tuấn, Khả Như, Oanh Kiều, Ngân Chi, Hữu Châu",
                            Poster="nang3-1-poster-scaled-cgv_1.jpg", Type="Hài, Tâm lý", Language="Tiếng Việt - Phụ đề Tiếng Anh",
                            Trailer="https://www.youtube.com/embed/cB2g13x_tcg", Rated="C16 - PHIM CẤM KHÁN GIẢ DƯỚI 16 TUỔI", Time=109,
                            PremiereDate=DateTime.Parse("2020-03-6"), Description="Lời Hứa Của Cha kể về cuộc sống của 2 mẹ con lừa đảo Quế Phương ( Khả Như ) và bé Hồng Ân ( Ngân Chi). Mọi thứ trở nên đảo lộn khi " +
                            "2 mẹ con vô tình lừa phải bác sĩ Tùng Sơn ( Kiều Minh Tuấn ), người có khả năng là cha mà bé Hồng Ân bấy lâu đang tìm kiếm. Hành trình chinh phục người cha bất đắc dĩ của 2 mẹ con không hề " +
                            "suôn sẻ khi gặp phải chướng ngại đáng gờm là Thùy Linh (Oanh Kiều), người yêu hiện tại của Sơn. Số phận nghiệt ngã còn trêu đùa và thử thách tình cha con hơn nữa khi đặt Hồng Ân vào tình huống hiểm nghèo."},

                new Film { Name="Truy Tìm Phép Thuật", Director="Dan Scanlon", Actor="",
                            Poster="poster_onward_official_1__1.jpg", Type="Hoạt Hình, Phiêu Lưu", Language="Tiếng Anh - Phụ đề Tiếng Việt",
                            Trailer="https://www.youtube.com/embed/UCfgXvSzllA", Rated="P - PHIM Dành Cho Mọi Lứa Tuổi", Time=103,
                            PremiereDate=DateTime.Parse("2020-03-06"), Description="Lấy bối cảnh vùng ngoại ô ở một thế giới thần tiên, " +
                            "hai anh em yêu tinh tuổi teen, Ian và Barley Lightfoot, cùng nhau tham gia vào một chuyến hành trình đi " +
                            "tìm chút phép thuật còn sót lại trên thế giới để có được một ngày gặp lại người cha thân yêu quá cố của mình."},

                new Film { Name="Tôi Là Não Cá Vàng", Director="Lê Hướng Nam", Actor="Khánh Hiền, Thu Trang, La Thành, Tuấn Trần, Kiều Minh Tuấn",
                            Poster="rsz_tlncv_teaser_poster_2.jpg", Type="Hài, Tình cảm", Language="Tiếng Việt - Phụ đề Tiếng Anh",
                            Trailer="https://www.youtube.com/embed/s-1DZTSmrk4", Rated="",
                            PremiereDate=DateTime.Parse("2020-06-05"), Description="Tôi Là Não Cá Vàng xoay quanh cuộc sống " +
                            "của một nhà thiết kế thời trang xinh đẹp nhưng mắc căn bệnh Alzheimer. " +
                            "Với cô, mỗi ngày đều là một ngày mới vì những ký ức ngày cũ dường như tan biến cả."},

                new Film { Name="Cơn Mưa Tình Đầu", Director="Arm Thatchaphong Suphasri", Actor="Mint Ranchrawee Uakoolwararat, New Thitipoom Techaapaikhun, Gee Sutthirak Subvijitra",
                            Poster="c_n_m_a_t_nh_u__cgv_2.jpg", Type="Tâm Lý, Tình cảm", Language="Tiếng Thái - Phụ đề Tiếng Việt",
                            Trailer="https://www.youtube.com/embed/9bKFCvtyKJg", Rated="",
                            PremiereDate=DateTime.Parse("2020-06-05"), Description="CƠN MƯA TÌNH ĐẦU (tựa gốc: CLASSIC AGAIN) là sự đan xen của hai câu chuyện " +
                            "tình yêu cách nhau 3 thập kỷ. Bota và cô bạn thân Poppy cùng cảm nắng Non – một anh " +
                            "bạn cùng trường đại học. Hiểu tấm lòng của người bạn thân, Bota giấu đi cảm xúc thật của " +
                            "mình để cổ vũ Poppy đến với Non. Một ngày, Bota tình cờ tìm thấy chiếc hộp cũ chứa đầy những lá thư " +
                            "và kỷ niệm về mối tình đầu của mẹ. Những bức thư giữa mẹ cô, Dalah và một chàng trai nhà nghèo " +
                            "tên Kajorn khiến Bota nhận ra cảm xúc hiện tại của mình thật giống với câu chuyện tình dở dang của mẹ. " +
                            "Liệu cô có dũng cảm giữ lấy tình yêu của mình hay mối tình đầu của Bota cũng sẽ kết thúc đầy tiếc nuối?"},

                new Film { Name="Gia Tài Tội Lỗi", Director="Vaughn Stein", Actor="Lily Collins, Simon Pegg, Connie Nielsen",
                            Poster="gia_tai_toi_loi___poster_1_.jpg", Type="Bí ẩn, Kịch tính", Language="Tiếng Việt - Phụ đề Tiếng Anh",
                            Trailer="https://www.youtube.com/embed/lY_1ptUWQFw", Rated="",
                            PremiereDate=DateTime.Parse("2020-06-12"), Description="Lauren Monroe (Lily Collins), " +
                            "một luật sư trẻ tuổi thành công và tham vọng, là con gái của một gia đình quyền lực " +
                            "và giàu có bậc nhất ở New York. Khi cha cô (Patrick Warburton) đột ngột qua đời, " +
                            "cô được trao chiếc chìa khóa dẫn đến một căn hầm tránh bom bí ẩn. Căn hầm này " +
                            "chứa đựng món thừa kế khổng lồ dành cho Lauren. Tuy nhiên, thay vì của cải vật chất, " +
                            "cô phát hiện \"món thừa kế\" của mình lại là một người đàn ông bí ẩn (Simon Pegg), " +
                            "bị nhốt và bị giam cầm trong nhiều năm trong căn hầm tối tăm. Lauren đứng trước sự lựa " +
                            "chọn giữa việc khám phá bí mật về người đàn ông đó hoặc quay trở lại cuộc sống bình thường, " +
                            "im lặng chấp nhận \"tài sản thừa kế đặc biệt\" của mình vì những gì Lauren khám phá ra được " +
                            "có thể sẽ đe dọa gia đình cô và tất cả những người xung quanh."}
            };
            films.ForEach(f => context.Films.Add(f));
            context.SaveChanges();

            var timeSlots = new List<TimeSlot>
            {
                new TimeSlot { Time = "8:30" },
                new TimeSlot { Time = "9:30" },
                new TimeSlot { Time = "10:30" },
                new TimeSlot { Time = "13:30" },
                new TimeSlot { Time = "15:30" },
                new TimeSlot { Time = "17:30" },
                new TimeSlot { Time = "20:30" },
                new TimeSlot { Time = "21:30" },
                new TimeSlot { Time = "22:30" },
                new TimeSlot { Time = "23:30" }
            };
            timeSlots.ForEach(t => context.TimeSlots.Add(t));
            context.SaveChanges();

            var showTimes = new List<ShowTimes>
            {
                new ShowTimes { FilmID = 1, Date = DateTime.Parse("2020-6-5"), TimeSlotID = 1, CinemaRoom = 1},
                new ShowTimes { FilmID = 1, Date = DateTime.Parse("2020-6-5"), TimeSlotID = 2, CinemaRoom = 2},
                new ShowTimes { FilmID = 1, Date = DateTime.Parse("2020-6-5"), TimeSlotID = 5, CinemaRoom = 3},
                new ShowTimes { FilmID = 2, Date = DateTime.Parse("2020-6-5"), TimeSlotID = 7, CinemaRoom = 4},
                new ShowTimes { FilmID = 2, Date = DateTime.Parse("2020-6-5"), TimeSlotID = 9, CinemaRoom = 5},
                new ShowTimes { FilmID = 3, Date = DateTime.Parse("2020-6-6"), TimeSlotID = 8, CinemaRoom = 6},
                new ShowTimes { FilmID = 4, Date = DateTime.Parse("2020-6-6"), TimeSlotID = 10, CinemaRoom = 7},
            };
            showTimes.ForEach(s => context.ShowTimes.Add(s));
            context.SaveChanges();

            var ticketBookings = new List<TicketBooking>
            {
                new TicketBooking { ChairID = 1, ShowTimesID = 1, UserID = 1},
                new TicketBooking { ChairID = 2, ShowTimesID = 2, UserID = 2},
                new TicketBooking { ChairID = 10, ShowTimesID = 1, UserID = 1},
                new TicketBooking { ChairID = 15, ShowTimesID = 2, UserID = 2}

            };
            ticketBookings.ForEach(t => context.TicketBookings.Add(t));
            context.SaveChanges();
        }
    }
}