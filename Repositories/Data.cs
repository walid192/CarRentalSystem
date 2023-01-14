
using Car_Rental_System.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace Car_Rental_System.Repositories
{
    public class Data
    {
		private readonly IWebHostEnvironment IWebHostEnvironment;
		public Data(IWebHostEnvironment webHostEnvironment)
		{
			this.IWebHostEnvironment = webHostEnvironment;
		}



        public string saveImage(IFormFile file)
        {
			string path = "";
			try
			{
				string wwwrootpath = IWebHostEnvironment.WebRootPath;
				path=Guid.NewGuid().ToString()+'_'+file.FileName;
				//string filename = Path.GetFileNameWithoutExtension(file.FileName);
				//string extension=Path.GetExtension(file.FileName);
				//filename = filename + extension;
				path=Path.Combine(wwwrootpath+"/Cars",path);
				using(var filestream= new FileStream(path,FileMode.Create)) 
				{
					file.CopyTo(filestream);
				}

            }
			catch (Exception)
			{

				throw;
			}
			return path;
        }



        public string SaveDriverImage(IFormFile file)
        {
            string path = "";
            try
            {
                string wwwrootpath = IWebHostEnvironment.WebRootPath;
                path = Guid.NewGuid().ToString() + '_' + file.FileName;
                path = Path.Combine(wwwrootpath + "/Drivers", path);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(filestream);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return path;
        }

        public static List<Car> GetAllCars() {
			List < Car > cars= new List<Car>{};
            Models.CarRentalSystemContext db = new Models.CarRentalSystemContext();
			cars = db.Cars.ToList();
			return cars;

        }



        public static List<Driver> GetAllDrivers()
        {
            List<Driver> drivers = new List<Driver> { };
            Models.CarRentalSystemContext db = new Models.CarRentalSystemContext();
            drivers = db.Drivers.ToList();
            return drivers;

        }


        public static List<Rent> GetAllRents()
        {
            List<Rent> rents = new List<Rent>();
            Models.CarRentalSystemContext db = new Models.CarRentalSystemContext();
            rents= db.Rents.ToList();
            return rents;

        }


        public static List<string> GetBrand() {


         List<string> brand =new List<string>();

            try
            {
                Models.CarRentalSystemContext db = new Models.CarRentalSystemContext();
                var test=from b in db.Cars select b.Brand;
                brand=test.Distinct().ToList();



            }
            catch (Exception)
            {

                throw;
            }

            return brand;


        }



        public static List<string> GetModels()
        {


            List<string> models = new List<string>();

            try
            {
                Models.CarRentalSystemContext db = new Models.CarRentalSystemContext();
                var test = from b in db.Cars select b.Model;
                models = test.Distinct().ToList();



            }
            catch (Exception)
            {

                throw;
            }

            return models;


        }



        public static List<string> GetDrivers()
        {


            List<string> drivers = new List<string>();

            try
            {
                Models.CarRentalSystemContext db = new Models.CarRentalSystemContext();
                var test = from b in db.Drivers select b.DriverName;
                drivers = test.ToList();



            }
            catch (Exception)
            {

                throw;
            }

            return drivers;


        }







    }
}
