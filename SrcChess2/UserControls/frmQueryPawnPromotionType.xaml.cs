﻿using System.Windows;
using SrcChess2.Classes;

namespace SrcChess2.UserControls {
    /// <summary>
    /// Ask user for the to pawn promotion piece
    /// </summary>
    public partial class frmQueryPawnPromotionType : Window {
        /// <summary>Pawn Promotion Piece</summary>
        private ChessBoard.ValidPawnPromotionE  m_eValidPawnPromotion;

        /// <summary>
        /// Class Ctor
        /// </summary>
        public frmQueryPawnPromotionType() {
            InitializeComponent();
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="eValidPawnPromotion">  The valid pawn promotion type</param>
        public frmQueryPawnPromotionType(ChessBoard.ValidPawnPromotionE eValidPawnPromotion) : this() {
            m_eValidPawnPromotion           = eValidPawnPromotion;
            radioButtonQueen.IsEnabled      = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Queen)  != ChessBoard.ValidPawnPromotionE.None);
            radioButtonRook.IsEnabled       = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Rook)   != ChessBoard.ValidPawnPromotionE.None);
            radioButtonBishop.IsEnabled     = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Bishop) != ChessBoard.ValidPawnPromotionE.None);
            radioButtonKnight.IsEnabled     = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Knight) != ChessBoard.ValidPawnPromotionE.None);
            radioButtonPawn.IsEnabled       = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Pawn)   != ChessBoard.ValidPawnPromotionE.None);
            if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Queen)  != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonQueen.IsChecked = true;
            } else if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Rook)   != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonRook.IsChecked  = true;
            } else if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Bishop) != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonBishop.IsChecked = true;
            } else if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Knight) != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonKnight.IsChecked = true;
            } else if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Pawn)   != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonPawn.IsChecked = true;
            }
        }

        /// <summary>
        /// Get the pawn promotion type
        /// </summary>
        public ChessBoard.MoveTypeE PromotionType {
            get {
                ChessBoard.MoveTypeE    eRetVal;
                
                if (radioButtonRook.IsChecked == true) {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToRook;
                } else if (radioButtonBishop.IsChecked == true) {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToBishop;
                } else if (radioButtonKnight.IsChecked == true) {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToKnight;
                } else if (radioButtonPawn.IsChecked == true) {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToPawn;
                } else {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToQueen;
                }
                return(eRetVal);
            }
        }

        /// <summary>
        /// Called when the Ok button is clicked
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event Parameter</param>
        private void butOk_Click(object sender, RoutedEventArgs e) {
            DialogResult    = true;
            Close();
        }
    } // Class frmQueryPawnPromotionType
} // Namespace
