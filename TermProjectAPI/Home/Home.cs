using System;

namespace TermProjectAPI
{
    public class Home
    {
        public String Homeaddress { get; set; }
        public String SellerUsername { get; set; }
        public String PropertyType { get; set; }
        public int HomeSize { get; set; }
        public int BedRoomNumber { get; set; }
        public int BathRoomNumber { get; set; }
        public String Amentities { get; set; }
        public String Utilities { get; set; }
        public int Yearbuilt { get; set; }
        public String Garage { get; set; }
        public String Description { get; set; }
        public int AskingPrice { get; set; }
        public String DateListed { get; set; }
        public String Photos { get; set; }


        public Home()
        {
        }

        public Home(String Homeaddress, String SellersUsername, String PropertyType, int HomeSize, int BedRoomNumber, int BathRoomNumber, String Amentities, String Utilities, int Yearbuilt, String Garage, String Description, int AskingPrice, String DateListed, String Photos)
        {
            this.Homeaddress = Homeaddress;
            this.SellerUsername = SellersUsername;
            this.PropertyType = PropertyType;
            this.HomeSize = HomeSize;
            this.BedRoomNumber = BedRoomNumber;
            this.BathRoomNumber = BathRoomNumber;
            this.Amentities = Amentities;
            this.Utilities = Utilities;
            this.Yearbuilt = Yearbuilt;
            this.Garage = Garage;
            this.Description = Description;
            this.AskingPrice = AskingPrice;
            this.DateListed = DateListed;
            this.Photos = Photos;

        }

    }
}