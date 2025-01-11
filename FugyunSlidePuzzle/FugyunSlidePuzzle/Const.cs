using System.Collections.Generic;

namespace FugyunSlidePuzzle
{
    /// <summary>
    /// 定数
    /// </summary>
    internal class Const
    {
        /// <summary>
        /// 左余白
        /// </summary>
        public const int MARGIN_LEFT = 20;

        /// <summary>
        /// 上余白
        /// </summary>
        public const int MARGIN_TOP = 190;

        /// <summary>
        /// ボタンテキストリスト（ＯＫ）
        /// </summary>
        public static readonly List<string> ButtonTextListOkOnly = new List<string>()
        {
            "ＯＫ"
        };

        /// <summary>
        /// ボタンテキストリスト（質問）
        /// </summary>
        public static readonly List<string> ButtonTextListForQustion = new List<string>()
        {
            "はい",
            "いいえ"
        };

        /// <summary>
        /// 全角数値リスト
        /// </summary>
        public static readonly List<string> FullWidthNumberList = new List<string>()
        {
            "０",
            "１",
            "２",
            "３",
            "４",
            "５",
            "６",
            "７",
            "８",
            "９"
        };
    }
}
