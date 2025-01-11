using System.Windows.Controls;

namespace FugyunSlidePuzzle
{
    /// <summary>
    /// 操作履歴情報
    /// </summary>
    internal class OperationHistoryInfo
    {
        #region プロパティ

        /// <summary>
        /// ピース番号
        /// </summary>
        public int PieceNumber { get; set; }

        /// <summary>
        /// 移動値
        /// （0：上・1：下・2：左・3：右）
        /// </summary>
        public int DirectionValue { get; set; }

        /// <summary>
        /// 対象イメージ
        /// </summary>
        public Image TargetImage { get; set; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="pieceNumber">ピース番号</param>
        /// <param name="directionValue">移動値（0：上・1：下・2：左・3：右）</param>
        /// <param name="targetImage">対象イメージ</param>
        public OperationHistoryInfo(int pieceNumber, int directionValue, Image targetImage)
        {
            PieceNumber = pieceNumber;
            DirectionValue = directionValue;
            TargetImage = targetImage;
        }

        #endregion
    }
}
