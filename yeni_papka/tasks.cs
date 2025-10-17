// using System;

// class Program
// {
//     static int MassivinCemi(int[] nums)
//     {
//         int cem = 0;
//         for (int i = 0; i < nums.Length; i++)
//         {
//             cem += nums[i];
//         }
//         return cem;
//     }

//     static void Main()
//     {
//         int[] ededler = new int[5];

//         Console.WriteLine("5 ədəd daxil edin:");

//         for (int i = 0; i < ededler.Length; i++)
//         {
//             Console.Write($"{i + 1}-ci ədəd: ");
//             ededler[i] = int.Parse(Console.ReadLine());
//         }

//         int cem = MassivinCemi(ededler);
//         Console.WriteLine("Massivin cəmi: " + cem);
//     }
// }



// using System;

// class Program
// {
//     static int [] massivSort(int [] nums)
//     {
//         Array.Sort(nums);
//         return nums ;
//     }

//     static void Main()
//     {
//         int [] newMassiv=massivSort(new int  [] {4,56,35,23,64});
//         Console.WriteLine(string.Join(", ", newMassiv));
        
//     }
// }


// using System;

// class Program
// {
//     static int [] massivReverse(int [] nums)
//     {
//         Array.Reverse(nums);
//         return nums ;
//     }

//     static void Main()
//     {
//         int [] newMassiv=massivReverse(new int  [] {4,56,35,23,64});
//         Console.WriteLine(string.Join(", ", newMassiv));
        
//     }
// }


// using System;

// class Program
// {
//     static void boyukKicik(int [] nums)
//     {
//         int index = 0;
//         int boyuk = nums[0];
//         int kicik = nums[0];
//         while (index<nums.Length){
//             if(nums[index]>boyuk){
//                 boyuk=nums[index];
//             }
//             if(nums[index]<kicik){
//                 kicik=nums[index];
//             }
//             index++;
//         }

//         Console.WriteLine(boyuk);
//         Console.WriteLine(kicik);
//     }

//     static void Main()
//     {
//         boyukKicik(new int  [] {4,56,35,23,64});
       
        
//     }
// }





// using System;

// class Program
// {
//     static void boyukKicik(int [] nums, int taplmali)
//     {
//         int index = 0;
//         int lamp = 0;
//         while (index<nums.Length){
//             if(nums[index]==taplmali){
//                 Console.WriteLine("Tapildi");
//                 lamp = 1;
//             }

//             index++;
//         }

//         if(lamp==0){
//             Console.WriteLine("Tapilmadi");
//         }

//     }

//     static void Main()
//     {
//         boyukKicik(new int  [] {4,56,35,23,64}, 3);
       
        
//     }
// }



// using System;

// class Program
// {
//     static void massivbuilder(int [] nums, int [] nums2)
//     {
//        int[] newMassiv = new int[nums.Length + nums2.Length];

//        int index = 0;

//        while (index<nums.Length){
//            newMassiv[index]=nums[index];
//            index++;
//        }

//         index = 0;

//        while (index<nums.Length){
//            newMassiv[index+nums.Length]=nums2[index];
//            index++;
//        }
//        Console.WriteLine(string.Join(", ", newMassiv));

//     }

//     static void Main()
//     {
//        massivbuilder(new int  [] {4,56,35,23,64}, new int [] {5,6,7,8,9});
       
        
//     }
// }




// using System;

// class Program
// {
//     static void UnikalElm(int[] nums)
//     {
//         for (int i = 0; i < nums.Length; i++)
//         {
//             int counter = 0;

//             for (int j = 0; j < nums.Length; j++)
//             {
//                 if (nums[i] == nums[j])
//                     counter++;
//             }

//             if (counter == 1)
//             {
//                 Console.Write(nums[i] + " ");
//             }
//         }

//         Console.WriteLine();
//     }

//     static void Main()
//     {
//         int[] massiv = { 4, 56, 35, 23, 64, 35, 56 };
//         UnikalElm(massiv);
//     }
// }






// using System;

// class Program
// {
//     static void boyukKicik(int [] nums)
//     {
//         int index = 0;
//         int cem=0;

//         while (index<nums.Length){
//             cem=cem+nums[index];

//             index++;
//         }

//         Console.WriteLine(cem/nums.Length);

//     }

//     static void Main()
//     {
//         boyukKicik(new int  [] {4,56,35,23,64});
       
        
//     }
// }




// using System;

// class Proqram
// {
//     static string MassiviMetneCevir(int[] massiv)
//     {
//         string netice = string.Join("-", massiv);
//         return netice;
//     }

//     static void Main()
//     {
//         int[] ededler = { 1, 2, 3, 4, 5 };
//         string metn = MassiviMetneCevir(ededler);

//         Console.WriteLine(metn);

//     }
// }





// using System;

// class Program
// {
//     static void massivbuilder3(int [] nums)
//     {
//        int[] newMassiv = new int[3];

//        int index = 0;

//        while (index<3){
//            newMassiv[index]=nums[index];
//            index++;
//        }

//         index = 0;


//        Console.WriteLine(string.Join(", ", newMassiv));

//     }

//     static void Main()
//     {
//        massivbuilder3(new int  [] {4,56,35,23,64});
       
        
//     }
// }
