using FinalProject.Infrastructures;
using FinalProject.Managers;
using System;
using System.Linq;
using System.Text;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Car system v.1";

            var brandMgr = new BrandManager();
            var modelMgr = new ModelManager();
            var carMgr = new CarManager();

        startMenu:
            PrintMenu();

            Menu m = ScannerManager.ReadMenu("İcra etmək istədiyiniz əməliyyatı seçin: ");

            switch (m)
            {
                case Menu.BrandAdd:
                    Console.Clear();
                    Brand b = new Brand();
                    b.Name = ScannerManager.ReadString("Markanın adını daxil edin: ");
                    brandMgr.Add(b);

                    goto case Menu.BrandAll;
                  
                case Menu.BrandEdit:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
            editedBrandId:
                    int v = ScannerManager.ReadInteger("Dəyişmək istədiyiniz markanın ID ni daxil edin: ");
                    var editedBrandId = brandMgr.GetAll().FirstOrDefault(id => id.Id == v);

                    if (editedBrandId == null)
                    {
                        ScannerManager.PrintError("Daxil etdiyiniz marka ID mövcud deyil, yenidən cəhd edin: ");
                        goto editedBrandId;
                    }
                    else
                    {
                        brandMgr.Edit(v);
                    }

                    goto case Menu.BrandAll;
                    
                case Menu.BrandRemove:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
            removedBrandId:
                    int id = ScannerManager.ReadInteger("Silmək istədiyiniz markanın ID ni daxil edin: ");

                    var b1 = brandMgr.GetAll().FirstOrDefault(i => i.Id == id);

                    if (b1 == null)
                    {
                        ScannerManager.PrintError("Daxil etdiyiniz marka ID mövcud deyil, yenidən cəhd edin: ");
                        goto removedBrandId;
                    }
                    else
                    {
                        brandMgr.Remove(b1);
                    }
                                     
                    goto case Menu.BrandAll;

                case Menu.BrandSingle:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
            singleBrandId:
                   int idSingleBrand = ScannerManager.ReadInteger("Ətraflı baxmaq istədiyiniz markanın ID ni daxil edin: ");

                    var bSingle = brandMgr.GetAll().FirstOrDefault(i => i.Id == idSingleBrand);
                    if (bSingle == null)
                    {
                        ScannerManager.PrintError("Daxil etdiyiniz marka ID mövcud deyil, yenidən cəhd edin: ");
                        goto singleBrandId;
                    }
                    else
                    {
                        Console.Clear();

                        brandMgr.ShowSingleBrand(idSingleBrand);

                        Console.WriteLine("---------- Modellər ----------");

                        foreach (var item in modelMgr.GetAll())
                        {
                            if (item.BrandId == idSingleBrand)
                                Console.WriteLine(item);
                        }
                    }
                    
                    goto startMenu;
                case Menu.BrandAll:
                    Console.Clear();
                    ShowAllBrands(brandMgr);

                    goto startMenu;

                case Menu.ModelAdd:
                    Console.Clear();

                    Model mod = new Model();
                    mod.Name = ScannerManager.ReadString("Modelin adını daxil edin: ");

                    ShowAllBrands(brandMgr);
            brandID:
                    mod.BrandId = ScannerManager.ReadInteger("Modeli əlavə etmək istədiyiniz markanın ID ni daxil edin: ");

                    var brID = brandMgr.GetAll().FirstOrDefault(item => item.Id == mod.BrandId);

                    if (brID == null)
                    {
                        ScannerManager.PrintError("Daxil etdiyiniz marka ID mövcud deyil, yenidən cəhd edin: ");
                        goto brandID;
                    }
                    else
                    {
                        modelMgr.Add(mod);
                    }
                    
                    goto case Menu.ModelAll;
                   
                case Menu.ModelEdit:
                    Console.Clear();
                    ShowAllModels(modelMgr);
            oneOrTwo:
                    Console.Write("Modelin adını dəyişmək üçün 1 ə | Modelin marka adını dəyişmək üçün 2 ə klikləyin: "); 

                    bool isSuccess = int.TryParse(Console.ReadLine(), out int number);
                    if (isSuccess && number == 1)
                    {
                    idModel:
                        int idOfModel = ScannerManager.ReadInteger("Dəyişəcək olan modelin ID ni daxil edin: ");
                        var modId = modelMgr.GetAll().FirstOrDefault(id => id.Id == idOfModel);

                        if (modId == null)
                        {
                            ScannerManager.PrintError("Daxil etdiyiniz model ID mövcud deyil, yenidən cəhd edin: ");
                            goto idModel;
                        }
                        else
                        {
                            modelMgr.EditModelName(idOfModel);
                        }                        
                    }
                    else if (isSuccess && number == 2)
                    {
                    modelId:
                        int idOfModel = ScannerManager.ReadInteger("Dəyişəcək olan modelin ID ni daxil edin: ");

                        var modId = modelMgr.GetAll().FirstOrDefault(id => id.Id == idOfModel);
                        if (modId == null)
                        {
                            ScannerManager.PrintError("Daxil etdiyiniz model ID mövcud deyil, yenidən cəhd edin: ");
                            goto modelId;
                        }
                        else
                        {
                        newBrand:
                            ShowAllBrands(brandMgr);
                            int brandNew = ScannerManager.ReadInteger("Yeni marka ID ni daxil edin: ");

                            var brandNewId = brandMgr.GetAll().FirstOrDefault(i => i.Id == brandNew);

                            if (brandNewId == null)
                            {
                                ScannerManager.PrintError("Daxil etdiyiniz marka ID mövcud deyil, yenidən cəhd edin: ");
                                goto newBrand;
                            }
                            else
                            {
                                ShowAllBrands(brandMgr);
                                modelMgr.EditBrandId(idOfModel, brandNew);
                            }                          
                        }                       
                    }
                    else
                    {
                        ScannerManager.PrintError("Seçim düzgün deyil, yenidən cəhd edin.");
                        goto oneOrTwo;
                    }

                    goto case Menu.ModelAll;
                   
                case Menu.ModelRemove:
                    Console.Clear();
                    ShowAllModels(modelMgr);
            modRem:
                    int idForRemove = ScannerManager.ReadInteger("Silmək istədiyiniz modelin ID ni daxil edin: ");

                    var mRem = modelMgr.GetAll().FirstOrDefault(i => i.Id == idForRemove);

                    if (mRem == null)
                    {
                        ScannerManager.PrintError("Daxil etdiyiniz model ID mövcud deyil, yenidən cəhd edin: ");
                        goto modRem;
                    }
                    else
                    {
                        modelMgr.Remove(mRem);
                    }
                   
                    goto case Menu.ModelAll;
                   
                case Menu.ModelSingle:
                    Console.Clear();
                    ShowAllModels(modelMgr);
            modSingle:
                    int idForSingle = ScannerManager.ReadInteger("Ətraflı baxmaq istədiyiniz modelin ID ni daxil edin: ");
                    

                    var sMod = modelMgr.GetAll().FirstOrDefault(i => i.Id == idForSingle);

                    if (sMod == null)
                    {
                        ScannerManager.PrintError("Daxil etdiyiniz model ID mövcud deyil, yenidən cəhd edin: ");
                        goto modSingle;
                    }
                    else
                    {
                        Console.Clear();
                        modelMgr.GetSingleModel(idForSingle);

                        Console.WriteLine("<<<<<<<<<<<<<<<<<<< Avtomobillər >>>>>>>>>>>>>>>>>>>");

                        foreach (var item in carMgr.GetAll())
                        {
                            if (item.ModelId == idForSingle)
                            {
                                Console.WriteLine(item);
                                Console.WriteLine("------------");
                            }
                               
                        }
                    }

                    goto startMenu;
                    
                case Menu.ModelAll:
                    Console.Clear();
                    ShowAllModels(modelMgr);

                    goto startMenu;
                   
                case Menu.CarAdd:
                    Console.Clear();

                    Car c = new Car();

                    c.Year = ScannerManager.ReadDate("Buraxılış ilini daxil edin: ");
                    c.Price = ScannerManager.ReadInteger("Qiyməti daxil edin: ");
                    c.Color = ScannerManager.ReadString("Rəngini daxil edin: ");
                    c.Engine = ScannerManager.ReadDouble("Mühərriki daxil edin: ");


                    PrintFuelTypeMenu();

                    l1:
                    FuelTypeMenu fuelType = ScannerManager.ReadFuelTypeMenu("Yanacaq növünü yuxarıdakı listdən seçin: ");

                    switch (fuelType)
                    {
                        case FuelTypeMenu.Benzene:
                            c.FuelType = nameof(FuelTypeMenu.Benzene);
                            break;
                        case FuelTypeMenu.Diesel:
                            c.FuelType = nameof(FuelTypeMenu.Diesel);
                            break;
                        case FuelTypeMenu.Hybrid:
                            c.FuelType = nameof(FuelTypeMenu.Hybrid);
                            break;
                        default:
                            ScannerManager.PrintError("Menudan seçin !");
                            goto l1;
                    }
                    
                    ShowAllModels(modelMgr);
            mId:
                    c.ModelId = ScannerManager.ReadInteger("Model ID ni daxil edin: ");

                    var cAdd = modelMgr.GetAll().FirstOrDefault(i => i.Id == c.ModelId);

                    if (cAdd == null)
                    {

                        ScannerManager.PrintError("Daxil etdiyiniz model ID mövcud deyil, yenidən cəhd edin: ");
                        goto mId;
                    }
                    else
                    {
                        carMgr.Add(c);
                        Console.WriteLine("***************************************");
                    }
                    
                    goto case Menu.CarAll;
                    
                case Menu.CarEdit:
                    Console.Clear();
            chooseOne:
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    Console.WriteLine("Buraxılış ilini dəyişmək => 1\n" +
                        "Qiymətini dəyişmək üçün => 2\n" +
                        "Rəngini dəyişmək üçün => 3\n" +
                        "Mühərriki dəyişmək üçün => 4\n" +
                        "Yanacaq növünü dəyişmək üçün => 5\n" +
                        "Modelini dəyişmək üçün => 6");
                    Console.WriteLine(new String('-', Console.WindowWidth));
            
                    Console.Write("1-6 arası bir rəqəm seçin: ");
                    bool isSuccess2 = int.TryParse(Console.ReadLine(), out int value);
                    Console.Clear();
                    if (isSuccess2 && value == 1)
                    {
                        ShowAllCars(carMgr);
                    carEdit:
                        int idCar = ScannerManager.ReadInteger("Seçilmiş avtomobilin ID ni daxil edin: ");                       
                    
                        var cEdit = carMgr.GetAll().FirstOrDefault(i => i.Id == idCar);

                        if (cEdit == null)
                        {
                            ScannerManager.PrintError("Daxil etdiyiniz avtomobil ID mövcud deyil, yenidən cəhd edin.");
                            goto carEdit;
                        }
                        else
                        {
                            carMgr.EditYear(value);
                        }
                       
                    }
                    else if (isSuccess2 && value ==2)
                    {
                        ShowAllCars(carMgr);
                    carEdit:
                        int idCar = ScannerManager.ReadInteger("Seçilmiş avtomobilin ID ni daxil edin: ");

                        var cEdit = carMgr.GetAll().FirstOrDefault(i => i.Id == idCar);

                        if (cEdit == null)
                        {
                            ScannerManager.PrintError("Daxil etdiyiniz avtomobil ID mövcud deyil, yenidən cəhd edin.");
                            goto carEdit;
                        }
                        else
                        {
                            carMgr.EditPrice(idCar);
                        }
                        
                    }
                    else if (isSuccess2 && value == 3)
                    {
                        ShowAllCars(carMgr);
                    carEdit:
                        int idCar = ScannerManager.ReadInteger("Seçilmiş avtomobilin ID ni daxil edin: ");

                        var cEdit = carMgr.GetAll().FirstOrDefault(i => i.Id == idCar);

                        if (cEdit == null)
                        {
                            ScannerManager.PrintError("Daxil etdiyiniz avtomobil ID mövcud deyil, yenidən cəhd edin.");
                            goto carEdit;
                        }
                        else
                        {
                            carMgr.EditColor(idCar);
                        }
                        
                    }
                    else if (isSuccess2 && value == 4)
                    {
                        ShowAllCars(carMgr);
                    carEdit:
                        int idCar = ScannerManager.ReadInteger("Seçilmiş avtomobilin ID ni daxil edin: ");

                        var cEdit = carMgr.GetAll().FirstOrDefault(i => i.Id == idCar);

                        if (cEdit == null)
                        {
                            ScannerManager.PrintError("Daxil etdiyiniz avtomobil ID mövcud deyil, yenidən cəhd edin.");
                            goto carEdit;
                        }
                        else
                        {
                            carMgr.EditEngine(idCar);
                        }                       
                    }
                    else if (isSuccess2 && value == 5)
                    {
                        ShowAllCars(carMgr);
                    carEdit2:
                        int idCar = ScannerManager.ReadInteger("Seçilmiş avtomobilin ID ni daxil edin: ");
                        var cEdit = carMgr.GetAll().FirstOrDefault(i => i.Id == idCar);

                        if (cEdit == null)
                        {
                            ScannerManager.PrintError("Daxil etdiyiniz avtomobil ID mövcud deyil, yenidən cəhd edin.");
                            goto carEdit2;
                        }
                        else
                        {
                            Console.Clear();
                            PrintFuelTypeMenu();
                            carMgr.EditFuelType(idCar);
                        }
         
                    }
                    else if (isSuccess2 && value == 6)
                    {
                        ShowAllCars(carMgr);
                    carEdit:
                        int idCar = ScannerManager.ReadInteger("Seçilmiş avtomobilin ID ni daxil edin: ");

                        var cEdit = carMgr.GetAll().FirstOrDefault(i => i.Id == idCar);

                        if (cEdit == null)
                        {
                            ScannerManager.PrintError("Daxil etdiyiniz avtomobil ID mövcud deyil, yenidən cəhd edin.");
                            goto carEdit;
                        }
                        else
                        {
                        modelId:
                            ShowAllModels(modelMgr);
                            int newModelId = ScannerManager.ReadInteger("Yeni model ID ni daxil edin: ");

                            var idOfNewModel = modelMgr.GetAll().FirstOrDefault(i => i.Id == newModelId);

                            if (idOfNewModel == null)
                            {
                                ScannerManager.PrintError("Daxil etdiyiniz model ID mövcud deyil, yenidən cəhd edin.");
                                goto modelId; 
                            }
                            carMgr.EditModelId(idCar, newModelId);
                        }

                        ShowAllModels(modelMgr);                        
                        
                    }
                    else
                    {
                        ScannerManager.PrintError("Seçim düzgün deyil, yenidən cəhd edin.");
                        goto chooseOne;
                    }

                    goto case Menu.CarAll;
                    
                case Menu.CarRemove:
                    Console.Clear();
                    ShowAllCars(carMgr);
            cRemove:
                    int idForRemoveCar = ScannerManager.ReadInteger("Silmək istədiyiniz avtomobilin ID ni daxil edin: ");

                    var cRem = carMgr.GetAll().FirstOrDefault(i => i.Id == idForRemoveCar);

                    if (cRem == null)
                    {
                        ScannerManager.PrintError("Daxil etdiyiniz avtomobil ID mövcud deyil, yenidən cəhd edin: ");
                        goto cRemove;
                    }
                    else
                    {
                        carMgr.Remove(cRem);
                    }

                    goto case Menu.CarAll;
                    
                case Menu.CarSingle:
                    Console.Clear();
                    ShowAllCars(carMgr);

            cSingle:
                    int idForSingleCar = ScannerManager.ReadInteger("Ətraflı baxmaq istədiyiniz avtomobilin ID ni daxil edin: ");

                    var cSingle = carMgr.GetAll().FirstOrDefault(i => i.Id == idForSingleCar);

                    if (cSingle == null)
                    {
                        ScannerManager.PrintError("Daxil etdiyiniz avtomobil ID mövcud deyil, yenidən cəhd edin: ");
                        goto cSingle;
                    }
                    else
                    {
                        Console.Clear();
                        carMgr.GetSingleCar(idForSingleCar);
                    }

                    goto startMenu;
                    
                case Menu.CarAll:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    goto startMenu;
                    
                case Menu.All:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    ShowAllModels(modelMgr);
                    ShowAllCars(carMgr);

                    goto startMenu;
                    
                case Menu.Exit:
                    goto endProgram;

                default:
                    ScannerManager.PrintError("Menudan seçin !");
                    goto startMenu;                             
            }

        endProgram:
            Console.WriteLine("Proqram bağlanır...\n" +
                "Çıxmaq üçün hər hansı bir düyməni klikləyin.");
            Console.ReadKey();
        }

        static void PrintMenu()
        {
            Console.WriteLine(new String('-',Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(Menu)))
            {
                Menu m = (Menu)Enum.Parse(typeof(Menu), item);
                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");               
            }
            Console.WriteLine(new String('-', Console.WindowWidth));
        }

        static void ShowAllBrands(BrandManager mgr)
        {
            Console.WriteLine("---------- Markalar ----------");
            Console.WriteLine(new String('*', Console.WindowWidth));
            foreach (var item in mgr.GetAll())
            {
                Console.WriteLine($">> {item}");
            }
            Console.WriteLine(new String('*', Console.WindowWidth));
        }

        static void ShowAllModels(ModelManager mgr)
        {
            Console.WriteLine("---------- Modellər ----------");
            Console.WriteLine(new String('*', Console.WindowWidth));
            foreach (var item in mgr.GetAll())
            {
                Console.WriteLine($">> {item}");
                
            }
            Console.WriteLine(new String('*', Console.WindowWidth));
        }

        static void ShowAllCars(CarManager mgr)
        {
            Console.WriteLine("---------- Maşınlar ----------");
            
            foreach (var item in mgr.GetAll())
            {
                Console.WriteLine(item);
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            }           
        }

        static void PrintFuelTypeMenu()
        {
            Console.WriteLine(new String('-', Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(FuelTypeMenu)))
            {
                FuelTypeMenu m = (FuelTypeMenu)Enum.Parse(typeof(FuelTypeMenu), item);
                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine(new String('-', Console.WindowWidth));
        }
    }
}
