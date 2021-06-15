using MVVMPairs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPairs.Services
{
    class Helper
    {
        public static Cell CurrentCell { get; set; }
        public static Cell PreviousCell { get; set; }
        public static ObservableCollection<ObservableCollection<Cell>> InitGameBoard()
        {
            ObservableCollection < ObservableCollection < Cell >> board = new ObservableCollection<ObservableCollection<Cell>>();

            for (int i = 0; i < 8; i++)
            {
                ObservableCollection<Cell> line = new ObservableCollection<Cell>();
                for (int j = 0; j < 8; j++)
                {
                    Cell cell = new Cell(i,j);

                    if ((i + j) % 2 == 0)
                    {
                        if (i < 3)
                        {
                            cell.Piece = "Red";
                        }
                        else if (i > 4)
                        { 
                            cell.Piece = "Black";
                         }
                    else
                            cell.Piece = "Normal";
                    }
                    else cell.Piece = "NormalLight";
                    line.Add(cell);
                }
                board.Add(line);
            }
            return board;
        }     
    }
}
