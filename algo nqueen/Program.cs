using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_nqueen
{
  
   

    class GFG
    {
        readonly int N = 4;

        //  (sonucu yazdırıyor)
        void printSolution(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 1)
                        Console.Write("Q ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
        }

       
        bool isSafe(int[,] board, int row, int col)
            // o noktanın kullanılabilir olup olmadığına bakıyor.
            //sadece sol tarafı kontrol etme sebebimiz algoritma soldan sağa ilerlediği için zaten sağ tarafında bir vezir bulunmasının imkansız olması
        {
            int i, j;

            // sol aynı satırı kontrol ediyor
            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            // sol üst tarafı kontrol ediyor
            for (i = row, j = col; i >= 0 &&
                j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            //sol alt tarafı kontrol ediyor
            for (i = row, j = col; j >= 0 &&
                        i < N; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        
        bool solveNQUtil(int[,] board, int col)
        {
           
            if (col >= N)
                return true;

            // tüm satırı koyulabilecek bir yer varmı diye kontrol ediyor board[i,col]
            for (int i = 0; i < N; i++)
            {
               
                if (isSafe(board, i, col))
                {
                    // koyulabilecek ise burayı 1 yapıyoruz board[i,col]
                    board[i, col] = 1;

                    //diğerleri için tekrar ediyoruz
                    if (solveNQUtil(board, col + 1) == true)
                        return true;

                    // eğer koyulan queen olmuyorsa onu siliyoruz
                    board[i, col] = 0; // BACKTRACK
                }
            }

            // bu satıra eğer bir queen yerleşmiyorsa false döndürüyoruz.
            return false;
        }

       //tahtayı oluşturuyoruz ve çözüm metodunu çağırıyoruz.
        bool solveNQ()
        {
            int[,] board = {{ 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }};

            if (solveNQUtil(board, 0) == false)
            {
                Console.Write("Solution does not exist");
                return false;
            }

            printSolution(board);
            return true;
        }

       
        public static void Main(String[] args)
        {
            GFG Queen = new GFG();
            Queen.solveNQ();
        }
    }

   

}
