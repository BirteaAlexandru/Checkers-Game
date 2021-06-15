using MVVMPairs.Models;
using MVVMPairs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVVMPairs.Services
{
    class GameBusinessLogic
    {
        private ObservableCollection<ObservableCollection<Cell>> cells;
        private List<Cell> posibleMoveList = new List<Cell>();
        private Cell cellBefore;
        string turn="Black";
        public GameBusinessLogic()
        {
        }
        public GameBusinessLogic(ObservableCollection<ObservableCollection<Cell>> cells)
        {
            this.cells = cells;
        }

        private void ChangeTurn()
        {
            if (turn == "Red")
                turn = "Black";
            else turn = "Red";
        }
        private void Move(Cell cellFirst, Cell cellSecond)
        {
            string auxiliar;
            auxiliar = cellFirst.Piece;
            cellFirst.Piece = cellSecond.Piece;
            cellSecond.Piece = auxiliar;

            if (Math.Abs(cellFirst.X - cellSecond.X) > 1)
            {
                cells[(cellFirst.X + cellSecond.X) / 2][(cellFirst.Y + cellSecond.Y) / 2].Piece = "Normal";
                deleteMoves();
                SeeMove(cellFirst);
                printMoves();
                if (posibleMoveList.Count() == 0)
                    ChangeTurn();
            }
            else
            {
                    ChangeTurn();
            }
        }
        private void printMoves()
        {
            foreach (Cell cell in posibleMoveList)
                cell.Piece = "Move";
        }
        private void deleteMoves()
        {
            foreach (Cell cell in posibleMoveList)
                cell.Piece = "Normal";
            posibleMoveList.Clear();
        }

        public void seeMoveUp(Cell currentCell)
        {
            string opposidePiece;
            if (currentCell.Piece == "Black")
            {
                opposidePiece = "Red";
            }
            else
            {
                opposidePiece = "Black";
            }

            if (currentCell.X > 0)
            {
                if (currentCell.Y > 0)
                {
                    if (cells[currentCell.X - 1][currentCell.Y - 1].Piece == "Normal")
                        posibleMoveList.Add(cells[currentCell.X - 1][currentCell.Y - 1]);
                    else
                    {
                        if (cells[currentCell.X - 1][currentCell.Y - 1].Piece == opposidePiece || cells[currentCell.X - 1][currentCell.Y - 1].Piece == opposidePiece +"Queen")
                            if (currentCell.X > 1 && currentCell.Y > 1)
                                if (cells[currentCell.X - 2][currentCell.Y - 2].Piece == "Normal")
                                {
                                    posibleMoveList.Add(cells[currentCell.X - 2][currentCell.Y - 2]);
                                    SeeMove(cells[currentCell.X - 2][currentCell.Y - 2]);
                                }
                    }

                }
                if (currentCell.Y < 7)
                {
                    if (cells[currentCell.X - 1][currentCell.Y + 1].Piece == "Normal")
                        posibleMoveList.Add(cells[currentCell.X - 1][currentCell.Y + 1]);
                    else
                    {
                        if (cells[currentCell.X - 1][currentCell.Y + 1].Piece == opposidePiece || cells[currentCell.X - 1][currentCell.Y - 1].Piece == opposidePiece+"Queen")
                            if (currentCell.X > 1 && currentCell.Y < 6)
                                if (cells[currentCell.X - 2][currentCell.Y + 2].Piece == "Normal")
                                {
                                    posibleMoveList.Add(cells[currentCell.X - 2][currentCell.Y + 2]);
                                    SeeMove(cells[currentCell.X - 2][currentCell.Y + 2] );
                                }
                    }

                }
            }
            else if(currentCell.Piece =="Black") 
                currentCell.Piece = "BlackQueen";
        }

        public void seeMoveDown(Cell currentCell)
        {
            string opposidePiece;
            if (currentCell.Piece == "Red")
                opposidePiece = "Black";
            else opposidePiece = "Red";

            if (currentCell.X < 7)
            {
                if (currentCell.Y > 0)
                {
                    if (cells[currentCell.X + 1][currentCell.Y - 1].Piece == "Normal")
                        posibleMoveList.Add(cells[currentCell.X + 1][currentCell.Y - 1]);
                    else
                    {
                        if (cells[currentCell.X + 1][currentCell.Y - 1].Piece == opposidePiece || cells[currentCell.X + 1][currentCell.Y - 1].Piece == opposidePiece+"Queen")
                            if (currentCell.X < 6 && currentCell.Y > 1)
                                if (cells[currentCell.X + 2][currentCell.Y - 2].Piece == "Normal")
                                {
                                    posibleMoveList.Add(cells[currentCell.X + 2][currentCell.Y - 2]);
                                    SeeMove(cells[currentCell.X + 2][currentCell.Y - 2]);
                                }
                    }

                }
                if (currentCell.Y < 7)
                {
                    if (cells[currentCell.X + 1][currentCell.Y + 1].Piece == "Normal")
                        posibleMoveList.Add(cells[currentCell.X + 1][currentCell.Y + 1]);
                    else
                    {
                        if (cells[currentCell.X + 1][currentCell.Y + 1].Piece == opposidePiece || cells[currentCell.X + 1][currentCell.Y - 1].Piece == opposidePiece+"Queen")
                            if (currentCell.X < 6 && currentCell.Y < 6)
                                if (cells[currentCell.X + 2][currentCell.Y + 2].Piece == "Normal")
                                {
                                    posibleMoveList.Add(cells[currentCell.X + 2][currentCell.Y + 2]);
                                    SeeMove(cells[currentCell.X + 2][currentCell.Y + 2]);
                                }
                    }

                }

            }
            else if (currentCell.Piece == "Red")
                 currentCell.Piece = "RedQueen";
        }
        private void SeeMove(Cell currentCell)
        {
            if (currentCell.Piece == "Black" )
            {
                seeMoveUp(currentCell);
            }
            else if (currentCell.Piece == "Red" )
            {
                seeMoveDown(currentCell);
            }
            else if(currentCell.Piece == "BlackQueen" )
            {
                seeMoveUp(currentCell);
                seeMoveDown(currentCell);
            }
            else if (currentCell.Piece == "RedQueen" )
            {
                seeMoveUp(currentCell);
                seeMoveDown(currentCell);
            }

           
        }

        public void ClickAction(Cell obj)
        {
            if (turn == "Red")
            {
                if (obj.Piece == "Red" || obj.Piece == "RedQueen" )
                {
                    deleteMoves();
                    SeeMove(obj);
                    printMoves();
                    cellBefore = obj;
                }
                else if (obj.Piece == "Move")
                {
                    deleteMoves();
                    Move(obj, cellBefore);
                }
            }
            else
            {
                if ( obj.Piece == "Black" || obj.Piece == "BlackQueen")
                {
                    deleteMoves();
                    SeeMove(obj);
                    printMoves();
                    cellBefore = obj;
                }
                else if (obj.Piece == "Move")
                {
                    deleteMoves();
                    Move(obj, cellBefore);
                }
            }
        }
    }
}
