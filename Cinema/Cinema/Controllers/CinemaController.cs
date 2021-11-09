using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;
using Cinema.Dal;
using System.Windows;
using Cinema.viewModel;

namespace Cinema.Controllers
{
    public class CinemaController : Controller
    {
        public static User user=null;
        public static int paypal;
        public ActionResult loginButton() { //כפתור התחברות   
            UserDal userDal = new UserDal();
            string userName = Request.Form["userName_name"].ToString();
            string password = Request.Form["password_name"].ToString();
            List<User> users = (from x in userDal.users where x.UserName.Contains(userName) && x.Password.Contains(password) select x).ToList<User>();
            if (users.Count != 0) {
                user = users[0];
                if (user.UserName.Contains("Admin"))
                    return View("adminPage");
                else
                    return View("homePage");
            }
            Response.Write("<script>alert('The username or password is incorrect');</script>");
            return View("login");
        }

        
        public ActionResult singUpButton(){ User user = new User();  return View("singUp",user);}
        public ActionResult backLoginButton() {return View("login");}
        public ActionResult logout() { user = null; return View("homePage"); }

        public ActionResult registerButton(User user) {
            UserDal userDal = new UserDal();
            List<User> temps = (from x in userDal.users where x.UserName.Contains(user.UserName) select x).ToList<User>();
            if (temps.Count==0)
            {
                userDal.users.Add(user);
                userDal.SaveChanges();
                return View("login");
            }
            Response.Write("<script>alert('Username already busy, please try again!');</script>");

             

            return View("singUp",user);

        } 

        public ActionResult login()
        {
            return View("login");
        }

        public ActionResult addMovie()//דף הוספת סרט
        {
            return View();
        }
       
        public ActionResult addMovieButton(Movie movie)//כפתור של הוספה בדף של הוספת סרט של אדמין
        {
            MovieDal movieDal = new MovieDal();
            List<Movie> chack= (from x in movieDal.movies where x.name.Contains(movie.name) select x).ToList<Movie>();
            if(chack.Count !=0)
            {
                Response.Write("<script>alert('The movie already exists, please try again!');</script>");
                return View("addMovie");
            }        
            movie.img = "/Content/images/" + movie.img;
            
            movieDal.movies.Add(movie);
            movieDal.SaveChanges();
            return View("adminPage");
        }
        public ActionResult addTime()//דף הוספת הקרנה
        {
            return View();
        }
        public ActionResult addTimebutton(Time time)//כפתור הוספת הקרנה
        {
            MovieDal movieDal = new MovieDal();
            List<string> chackName = (from x in movieDal.movies  select x.name).ToList<string>();
            if (!(chackName.Contains(time.name))){
                Response.Write("<script>alert('There is no movie with such a name!, please try again!');</script>");//הודעה שלא קיים סרט כזה
                return View("addTime");
            }
            else {
                TimeDal timeDal = new TimeDal();
                
                List<Time> chack = (from x in timeDal.times where x.date.Contains(time.date) && x.hour.Contains(time.hour) && x.hall.Contains(time.hall) select x).ToList<Time>();
                if (chack.Count != 0)
                {
                    Response.Write("<script>alert('There's already a movie on this date in this hall!');</script>");
                    //הודעה שאי אפשר להחליף אולם כי יש סרט בשעה ובאולם הזה כבר
                    return View("addTime"); 
                }
                else
                {
                    timeDal.times.Add(time);
                    timeDal.SaveChanges();
                    return View("adminPage");
                }
                

            }

           
        }


        public ActionResult ChangeNumSeatsAdmin()//דף שינוי מספר כיסאות באולם
        {
            HallDal hallDal = new HallDal();
            HallViewModel hvm = new HallViewModel();
            hvm.halls= (from x in hallDal.halls select x).ToList<Hall>();
            return View("ChangeNumSeat",hvm);
        }
        public ActionResult ChangeNumSeats( string name)//כפתור שינוי מספר כיסאות באולם
        {
            HallDal hallDal = new HallDal();
            Hall temp = new Hall();
            int newNum = int.Parse(Request.Form[name]);
            temp= (from x in hallDal.halls where x.name.Contains(name) select x).ToList<Hall>()[0];
            hallDal.halls.Remove(temp);
            hallDal.SaveChanges();
            temp.numSeat = newNum;
            hallDal.halls.Add(temp);
            hallDal.SaveChanges();
            return ChangeNumSeatsAdmin();
        }
        public ActionResult ChangeHallAdmin()//דף שינוי אולם להקרנה
        {
            ShowsViewModel svm = new ShowsViewModel();svm.shows = new List<Show>();
            MovieDal movieDal = new MovieDal();
            TimeDal timeDal = new TimeDal();
            List<Time> temps = (from x in timeDal.times select x).ToList<Time>();
            foreach (Time obj in temps.ToList<Time>())
            {
                string[] time_split = obj.hour.Split(':');
                string[] date_split = obj.date.Split('-');
                DateTime timeMove = new DateTime(int.Parse(date_split[0]), int.Parse(date_split[1]), int.Parse(date_split[2]), int.Parse(time_split[0]), int.Parse(time_split[1]), 0);
                if (DateTime.Now > timeMove)
                    temps.Remove(obj);
                else
                {
                    Show temp = new Show();
                    List<Movie> movies = (from x in movieDal.movies where x.name.Contains(obj.name) select x).ToList<Movie>();
                     
                    if (movies.Count !=0)
                    {
                        temp.movie = movies[0];
                        temp.time = obj;
                        svm.shows.Add(temp);
                    }
                }
            }
                return View("changeHall",svm);  
        }
        public ActionResult ChangeHall(Time time,string index)//כפתור שינוי אולם להקרנה
        {
            TimeDal timeDal = new TimeDal();
            string newHall = Request[index].ToString();
            List<Time> chack = (from x in timeDal.times where x.date.Contains(time.date) && x.hour.Contains(time.hour) && x.hall.Contains(newHall) select x).ToList<Time>();
            if (chack.Count != 0)
            {
                Response.Write("<script>alert('There's already a movie on this date in this hall!');</script>");
                //הודעה שאי אפשר להחליף אולם כי יש סרט באולם הזה כבר
                return ChangeHallAdmin();
            }
            Time temp = (from x in timeDal.times where x.date.Contains(time.date) && x.hour.Contains(time.hour) && x.name.Contains(time.name) && x.hall.Contains(time.hall) select x).ToList<Time>()[0];
            timeDal.times.Remove(temp);
            timeDal.SaveChanges();
            temp.hall = newHall;
            timeDal.times.Add(temp);
            timeDal.SaveChanges();
            return ChangeHallAdmin();
        }
        public ActionResult changePriceAdmin()//דף שינוי מחיר לסרט
        {
            MovieViewModel mvm = new MovieViewModel();
            MovieDal movieDal = new MovieDal();
            mvm.movies = (from x in movieDal.movies select x).ToList<Movie>();
            return View("changePrice", mvm);
            
        }
        public ActionResult changePrice(string name)//כפתור שינוי מחיר לסרט
        {
            string newprice = Request[name].ToString();
            MovieDal movieDal = new MovieDal();
            Movie temp = (from x in movieDal.movies where x.name.Contains(name) select x).ToList<Movie>()[0];
            movieDal.movies.Remove(temp);
            movieDal.SaveChanges();
            temp.price = int.Parse(newprice);
            movieDal.movies.Add(temp);
            movieDal.SaveChanges();
            return changePriceAdmin();
        }
        public ActionResult removeButton(string name)//הסרת סרט של אדמין
        {
            MovieDal movieDal = new MovieDal();
            Movie temp = (from x in movieDal.movies where x.name.Contains(name) select x).ToList<Movie>()[0];
            movieDal.movies.Remove(temp);
            movieDal.SaveChanges();
            return removeAdmin();
        }
        public ActionResult removeAdmin()//דף הסרת סרט
        {
            MovieViewModel mvm = new MovieViewModel();
            MovieDal movieDal = new MovieDal();
            mvm.movies = (from x in movieDal.movies  select x).ToList<Movie>();
            return View("removeMovie",mvm);
        }

        public ActionResult remove(string userName, string name, string date, string hour, string seats)//הסרה של עגלה
        {
            CartDal cartDal = new CartDal();
            Cart oldCart = (from x in cartDal.carts where x.date.Contains(date) && x.hour.Contains(hour) && x.name.Contains(name) && x.userName.Contains(user.UserName) && x.seats.Contains(seats) select x).ToList<Cart>()[0];
            cartDal.carts.Remove(oldCart);
            cartDal.SaveChanges();
            return cart();
        }
        public ActionResult changeDB(string userName, string name, string date,string hour,string oldSeats)//כפתור שינוי מקומות אחרי שבחרתי אותם באולם
        {
            CartDal cartDal = new CartDal();
            Cart newCart = new Cart();
            newCart.userName = userName; newCart.name = name; newCart.date = date; newCart.hour = hour;
            newCart.seats = Request.Form["seatCartName"].ToString();
            newCart.subtotal = Request.Form["subTotalName"].ToString();
            Cart oldCart=(from x in cartDal.carts where x.date.Contains(date) && x.hour.Contains(hour) && x.name.Contains(name) && x.userName.Contains(user.UserName) && x.seats.Contains(oldSeats) select x).ToList<Cart>()[0];
            cartDal.carts.Remove(oldCart);
            cartDal.SaveChanges();
            cartDal.carts.Add(newCart);
            cartDal.SaveChanges();
            return View("homePage");
        }
        public ActionResult change( string userName, string name, string date, string hour, string oldSeats)//כפתור שינוי מקומות בעגלה(הכפתור התכלת
        {
            ChangeViewModel cvm = new ChangeViewModel();
            MovieDal movieDal = new MovieDal();
            HallDal hallDal = new HallDal();
            OrderDal orderDal = new OrderDal();
            TimeDal timeDal = new TimeDal();
            cvm.movie = (from x in movieDal.movies where x.name.Contains(name) select x).ToList<Movie>()[0];
            string hallMove = (from x in timeDal.times where x.date.Contains(date) && x.hour.Contains(hour) && x.name.Contains(name) select x.hall).ToList<string>()[0];
            cvm.hall = (from x in hallDal.halls where x.name.Contains(hallMove) select x).ToList<Hall>()[0];
            cvm.date = date;cvm.oldSeats = oldSeats; cvm.time = hour;cvm.userName = userName;
            cvm.orders= (from x in orderDal.orders where x.date.Contains(date) && x.hour.Contains(hour) && x.hall.Contains(hallMove) select x).ToList<Order>();
            return View("ChangeSeats",cvm);
        }
        public ActionResult test()
        {
            Random random = new Random();
            
            TimeDal timeDal = new TimeDal();
            OrderDal orderDal = new OrderDal();
            HallDal hallDal = new HallDal();
            List<Time> times=(from x in timeDal.times select x).ToList<Time>();
            foreach (Time t in times)
            {
                
                    Hall hall = (from x in hallDal.halls where x.name.Contains(t.hall) select x).ToList<Hall>()[0];
                    for(int i = 1; i <= hall.numSeat; i++)
                    {
                        bool x2 = random.Next(2) == 0;
                        if (x2)
                        {
                            Order order = new Order();
                            order.nameMovie = t.name;
                            order.date = t.date;
                            order.hour = t.hour;
                            order.hall = t.hall;
                            order.seat = "" + i;
                            orderDal.orders.Add(order);
                            orderDal.SaveChanges();
                        }
                    }
                

            }
            return View("homePage");
        }
        public ActionResult adminPage()
        {
            return View();
        }
        public ActionResult homePage()
        {

            return View();
        }
        public ActionResult cart()
        { 
                CartDal cartDal = new CartDal();
                MovieDal movieDal = new MovieDal();
                CartViewModel cvm = new CartViewModel();
                cvm.carts = (from x in cartDal.carts where x.userName.Contains(user.UserName) select x).ToList<Cart>();
            
            foreach(Cart obj in cvm.carts)
            {    
                obj.movie = (from x in movieDal.movies where x.name.Contains(obj.name) select x).ToList<Movie>()[0]; 
            }
            return View("cart",cvm);
        }

        public ActionResult add(string name)//הכפתור של דף מידע על סרט
        {
            MovieDal movieDal = new MovieDal();
            OrderViewModel ovm = new OrderViewModel();
            OrderDal orderDal = new OrderDal();
            HallDal hallDal = new HallDal();
            TimeDal timeDal = new TimeDal();
            ovm.user = user;
            ovm.movie = (from x in movieDal.movies where x.name.Contains(name) select x).ToList<Movie>()[0]; 
            string[] temp = (Request.Form["selectDate"].ToString()).Split('*');
            ovm.date = temp[0];
            ovm.hour = temp[1];
            string hallMove = (from x in timeDal.times where x.date.Contains(ovm.date)&& x.hour.Contains(ovm.hour)&& x.name.Contains(name) select x.hall).ToList<string>()[0];
            ovm.hall = (from x in hallDal.halls where x.name.Contains(hallMove) select x).ToList<Hall>()[0];
            ovm.orders = (from x in orderDal.orders where x.date.Contains(ovm.date) && x.hour.Contains(ovm.hour) && x.hall.Contains(hallMove) select x).ToList<Order>();
            return View("seat",ovm);
        }

        
        public ActionResult buy( string name,string date,string hour, string hall)//כפתור קניה לאחר בחירת כיסאות ברגיל
        {
            OrderDal orderDal = new OrderDal();
            string[] seats = (Request.Form["seatName"].ToString()).Split(',');
            paypal = int.Parse(Request.Form["subTotalNamepay"].ToString());
            for (int i=0;i<seats.Length;i++){
                Order order = new Order();
                order.date = date; order.hall = hall; order.hour = hour; order.nameMovie = name;
                order.seat = seats[i];
                orderDal.orders.Add(order);
                orderDal.SaveChanges();
            }

            return View("payment");
        }
        public ActionResult addCart(string userName,string name, string date, string hour)
        {
            Cart cart = new Cart();
            cart.seats=Request.Form["seatCartName"].ToString();
            cart.subtotal = Request.Form["subTotalName"].ToString();        
            cart.userName = userName;cart.name=name; cart.date=date; cart.hour =hour;
            CartDal cartDal = new CartDal(); 
            cartDal.carts.Add(cart);
            cartDal.SaveChanges();
          
            return View("homePage");
        }
        public ActionResult pay()
        {
            Payment payment = new Payment();
            PayDal payDal = new PayDal();
            payment.numCard = Request.Form["numCardName"].ToString();
            payment.name = Request.Form["nameName"].ToString();
            List<Payment> temp = (from x in payDal.payments where x.numCard.Contains(payment.numCard) select x).ToList<Payment>();
            if(temp.Count==0)
            {
                payDal.payments.Add(payment);
                payDal.SaveChanges();
            }
            Response.Write("<script>alert('Payment passed successfully !! :-)');</script>");
            return View("homePage");
        }

        public ActionResult MovieGallery()
        {
            MovieViewModel mvm = new MovieViewModel();
            MovieDal movieDal = new MovieDal();
            mvm.movies=(from x in movieDal.movies select x).ToList<Movie>();
            return View(mvm);
        }
        public ActionResult info_movie(string name)
        {     
            MovieInfoViewModel mivm = new MovieInfoViewModel();
            MovieDal movieDal =new MovieDal();
            TimeDal timeDal = new TimeDal();
            mivm.movie=(from x in movieDal.movies where x.name.Contains(name) select x).ToList<Movie>()[0];
            mivm.dates = (from x in timeDal.times where x.name.Contains(name) select x).ToList<Time>();
            foreach(Time obj in mivm.dates.ToList<Time>())
            {
                string[] time_split = obj.hour.Split(':');
                string[] date_split = obj.date.Split('-');
                DateTime timeMove=new DateTime(int.Parse(date_split[0]), int.Parse(date_split[1]), int.Parse(date_split[2]), int.Parse(time_split[0]), int.Parse(time_split[1]), 0);
                if (DateTime.Now > timeMove)
                    mivm.dates.Remove(obj);
            }
            return View("moviePage", mivm);
        }
        public ActionResult payment()//דף תשלום ישירות מסרט
        {
           
            return View();

        }
        public ActionResult paymentCart()//דף תשלום על עגלה כולה
        {

            return View();
        }
        public ActionResult paymentCartButton()//כפתור תשלום של דף תשלום של עגלה
        {
            TimeDal timeDal = new TimeDal();
            CartDal cartDal = new CartDal();
            OrderDal orderDal = new OrderDal();
            List<Cart> temps = (from x in cartDal.carts where x.userName.Contains(user.UserName) select x).ToList<Cart>();
            foreach (Cart cart in temps)
            {
                foreach (String seat in cart.seats.Split(','))
                {
                    Order order = new Order();order.nameMovie = cart.name;order.date = cart.date;order.hour = cart.hour; order.seat = seat;
                    order.hall =(from x in timeDal.times where x.date.Contains(order.date) 
                                                                && x.hour.Contains(order.hour) 
                                                                && x.name.Contains(order.nameMovie) select x.hall).ToList<string>()[0];
                    orderDal.orders.Add(order);
                    orderDal.SaveChanges();

                }
            }
            foreach (Cart obj in temps.ToList<Cart>())
            {
                cartDal.carts.Remove(obj);
                cartDal.SaveChanges();
            }
            return pay();
        }

        public ActionResult order(string name)
        {
            TimeDal timeDal = new TimeDal();
            OrderDal orderDal = new OrderDal();
            MovieViewModel mvm = new MovieViewModel();
            MovieDal movieDal = new MovieDal();
            if (name == "up")
            {
                mvm.movies = (from x in movieDal.movies select x).ToList<Movie>();
                foreach(Movie m in mvm.movies)
                {
                    m.salePrice = (m.salePrice == 0) ? m.price : m.salePrice;
                }
                mvm.movies = mvm.movies.OrderBy(o => (o.salePrice)).ToList<Movie>();
                foreach (Movie m in mvm.movies)
                {
                    m.salePrice = (m.salePrice == m.price) ? 0 : m.salePrice;
                }
            }
            else if (name == "down")
            {
                mvm.movies = (from x in movieDal.movies select x).ToList<Movie>();
                foreach (Movie m in mvm.movies)
                {
                    m.salePrice = (m.salePrice == 0) ? m.price : m.salePrice;
                }
                mvm.movies = mvm.movies.OrderByDescending(o => (o.salePrice)).ToList<Movie>();
                foreach (Movie m in mvm.movies)
                {
                    m.salePrice = (m.salePrice == m.price) ? 0 : m.salePrice;
                }
            }
            else if (name == "category")
            {
                string category = Request.Form["selectName"].ToString();
                mvm.movies = (from x in movieDal.movies where x.category.Contains(category) select x ).ToList<Movie>();
              


            }
            else if (name == "sale")
            {
                
                mvm.movies = (from x in movieDal.movies where x.salePrice!=0 select x).ToList<Movie>();
                mvm.movies = mvm.movies.OrderByDescending(x => x.salePrice).ToList();
            }
            else if (name == "age")
            {
                mvm.movies = (from x in movieDal.movies where x.age>=18 select x).ToList<Movie>();

            }
            else if (name == "most popular")
            {
                mvm.movies = new List<Movie>();
                List<popular> temps = orderDal.orders
                .GroupBy(x => x.nameMovie)
                .Select(y => new popular
                {
                    nameMovie = y.Key,
                    numOrder = y.Count()
                }).ToList();
                temps = temps.OrderByDescending(x => x.numOrder).ToList();                foreach (popular obj in temps)                {                    Movie movie= (from x in movieDal.movies where x.name.Contains(obj.nameMovie) select x).ToList<Movie>()[0];                    mvm.movies.Add(movie);                }

            }
            else if (name == "range price")
            {
                int limit = int.Parse(Request.Form["slider"]);
                mvm.movies = (from x in movieDal.movies where x.price<= limit||(x.salePrice<=limit&&x.salePrice!=0) select x).ToList<Movie>();

            }
            else if (name == "range date")
            {
                string limit = Request.Form["limitDate"].ToString();
                List<string> names = (from x in timeDal.times where x.date.Contains(limit) select x.name).ToList<string>();
                mvm.movies = (from x in movieDal.movies where names.Contains(x.name)  select x).ToList<Movie>();

            }
            else if (name == "range time")
            {
                string limit = Request.Form["limitTime"].ToString();
                List<string> names = (from x in timeDal.times where x.hour.Contains(limit) select x.name).ToList<string>();
                mvm.movies = (from x in movieDal.movies where names.Contains(x.name) select x).ToList<Movie>();

            }
            else
            {
                mvm.movies = (from x in movieDal.movies select x).ToList<Movie>();
            }

            return View("MovieGallery",mvm);
        }
    }

}