using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FugyunSlidePuzzle
{
    /// <summary>
    /// CustomMessageBox.xaml の相互作用ロジック
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        #region 定数

        /// <summary>
        /// 戻り値：ボタン１
        /// </summary>
        public const string RETURN_BUTTON1 = "Button1";

        /// <summary>
        /// 戻り値：ボタン２
        /// </summary>
        public const string RETURN_BUTTON2 = "Button2";

        /// <summary>
        /// 戻り値：ボタン３
        /// </summary>
        public const string RETURN_BUTTON3 = "Button3";

        #endregion

        #region プロパティ

        /// <summary>
        /// 戻り値
        /// </summary>
        public string MessageBoxResult { get; set; }

        /// <summary>
        /// デフォルトボタン値
        /// 0：Button1
        /// 1：Button2
        /// 3：Button3
        /// </summary>
        private int DefaultButtonValue { get; set; }

        /// <summary>
        /// ビープ音値
        /// 0：無し
        /// 1：情報・警告
        /// 2：エラー
        /// </summary>
        private int BeepSoundValue { get; set; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        #endregion

        #region イベント

        /// <summary>
        /// ウィンドウ描画後処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            // デフォルトボタン値を判定する。
            if (1 == DefaultButtonValue)
            {
                Button1.Focus();
            }
            else if (2 == DefaultButtonValue)
            {
                Button2.Focus();
            }
            else if (3 == DefaultButtonValue)
            {
                Button3.Focus();
            }

            // ビープ音値を判定する。
            if (1 == BeepSoundValue)
            {
                SystemSounds.Beep.Play();
            }
            else if (2 == BeepSoundValue)
            {
                SystemSounds.Hand.Play();
            }
        }

        /// <summary>
        /// ウィンドウキー押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                Clipboard.SetText(MessageTextBlock.Text);
            }
        }

        /// <summary>
        /// ボタン１押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = RETURN_BUTTON1;
            Close();
        }

        /// <summary>
        /// ボタン２押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = RETURN_BUTTON2;
            Close();
        }

        /// <summary>
        /// ボタン３押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = RETURN_BUTTON3;
            Close();
        }

        #endregion

        #region ヘルパーメソッド

        /// <summary>
        /// メッセージボックス設定処理
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="iconNo">アイコン番号（0：情報・1：エラー・2：警告・3：質問）</param>
        /// <param name="buttonTextList">ボタンテキストリスト</param>
        /// <param name="defaultButtonValue">デフォルトボタン値（1：Button1・2：Button2・3：Button3）</param>
        /// <param name="beepSoundValue">ビープ音値（0：無し・1：情報・警告・2：エラー）</param>
        public void MessageBoxSetting(
            string message,
            int iconNo,
            List<string> buttonTextList,
            int defaultButtonValue,
            int beepSoundValue)
        {
            // メッセージを設定する。
            MessageTextBlock.Text = message;

            // ボタン・余白線を非表示にする。
            Button2.Visibility = Visibility.Collapsed;
            Button3.Visibility = Visibility.Collapsed;
            Border1.Visibility = Visibility.Collapsed;
            Border2.Visibility = Visibility.Collapsed;

            // アイコンを設定する。
            if (0 == iconNo)
            {
                // 情報
                InfomationImage.Visibility = Visibility.Visible;
                RenderOptions.SetBitmapScalingMode(InfomationImage, BitmapScalingMode.HighQuality);
            }
            else if (1 == iconNo)
            {
                // エラー
                ErrorImage.Visibility = Visibility.Visible;
                RenderOptions.SetBitmapScalingMode(ErrorImage, BitmapScalingMode.HighQuality);
            }
            else if (2 == iconNo)
            {
                // 警告
                WarningImage.Visibility = Visibility.Visible;
                RenderOptions.SetBitmapScalingMode(WarningImage, BitmapScalingMode.HighQuality);
            }
            else
            {
                // 質問
                QuestionImage.Visibility = Visibility.Visible;
                RenderOptions.SetBitmapScalingMode(QuestionImage, BitmapScalingMode.HighQuality);
            }

            // ボタンテキストリストの項目数を判定する。
            if (1 == buttonTextList.Count)
            {
                Button1.Content = buttonTextList[0];
            }
            else if (2 == buttonTextList.Count)
            {
                Button2.Visibility = Visibility.Visible;
                Border1.Visibility = Visibility.Visible;
                Button1.Content = buttonTextList[0];
                Button2.Content = buttonTextList[1];
            }
            else if (3 == buttonTextList.Count)
            {
                Button2.Visibility = Visibility.Visible;
                Button3.Visibility = Visibility.Visible;
                Border1.Visibility = Visibility.Visible;
                Border2.Visibility = Visibility.Visible;
                Button1.Content = buttonTextList[0];
                Button2.Content = buttonTextList[1];
                Button3.Content = buttonTextList[2];
            }

            // デフォルトボタン値を設定する。
            DefaultButtonValue = defaultButtonValue;

            // ビープ音値を設定する。
            BeepSoundValue = beepSoundValue;

            // ウィンドウサイズを設定する。
            // （画面表示前だとテキストブロックのサイズが取得出来ないため、以下の方法で取得する。）
            var formattedText = new FormattedText(
                MessageTextBlock.Text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(MessageTextBlock.FontFamily, MessageTextBlock.FontStyle, MessageTextBlock.FontWeight, MessageTextBlock.FontStretch),
                MessageTextBlock.FontSize,
                Brushes.Black,
                VisualTreeHelper.GetDpi(this).PixelsPerDip);

            // 幅・高さを設定する。
            Width = 180 + formattedText.Width;
            Height = 220 + formattedText.Height;
        }

        #endregion
    }
}
