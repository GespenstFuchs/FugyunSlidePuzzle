using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FugyunSlidePuzzle
{
    /// <summary>
    /// ColorPicker.xaml の相互作用ロジック
    /// </summary>
    public partial class ColorPicker : Window
    {
        #region プロパティ

        /// <summary>
        /// Brush変換クラス
        /// </summary>
        private BrushConverter BrushConverter { get; } = new BrushConverter();

        /// <summary>
        /// カラーボタンリスト
        /// </summary>
        private List<Button> ColorButtonList { get; set; }

        /// <summary>
        /// カラー値テキストボックスリスト
        /// </summary>
        private List<TextBox> ColorValueTextBoxList { get; set; }

        /// <summary>
        /// 選択ブラシ
        /// </summary>
        public Brush SelectedBrush { get; private set; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="selectedBrush">選択ブラシ</param>
        public ColorPicker(Brush selectedBrush)
        {
            InitializeComponent();

            ColorValueTextBoxList = new List<TextBox>()
            {
                RedValueTextBox,
                GreenValueTextBox,
                BlueValueTextBox,
                AlphaValueTextBox
            };

            // 色を取得する。
            if (!(selectedBrush is SolidColorBrush solidColorBrush))
            {
                // null（透明）の場合
                return;
            }

            RedSlider.Value = solidColorBrush.Color.R;
            GreenSlider.Value = solidColorBrush.Color.G;
            BlueSlider.Value = solidColorBrush.Color.B;
            AlphaSlider.Value = solidColorBrush.Color.A;

            ColorButtonList = new List<Button>()
            {
                C101Button, C102Button, C103Button, C104Button, C105Button, C106Button, C107Button, C108Button, C109Button, C110Button, C111Button, C112Button, C113Button, C114Button, C115Button, C116Button, C117Button, C118Button, C119Button, C120Button, C121Button, C122Button, C123Button, C124Button, C125Button, C126Button, C127Button, C128Button,
                C201Button, C202Button, C203Button, C204Button, C205Button, C206Button, C207Button, C208Button, C209Button, C210Button, C211Button, C212Button, C213Button, C214Button, C215Button, C216Button, C217Button, C218Button, C219Button, C220Button, C221Button, C222Button, C223Button, C224Button, C225Button, C226Button, C227Button, C228Button,
                C301Button, C302Button, C303Button, C304Button, C305Button, C306Button, C307Button, C308Button, C309Button, C310Button, C311Button, C312Button, C313Button, C314Button, C315Button, C316Button, C317Button, C318Button, C319Button, C320Button, C321Button, C322Button, C323Button, C324Button, C325Button, C326Button, C327Button, C328Button,
                C401Button, C402Button, C403Button, C404Button, C405Button, C406Button, C407Button, C408Button, C409Button, C410Button, C411Button, C412Button, C413Button, C414Button, C415Button, C416Button, C417Button, C418Button, C419Button, C420Button, C421Button, C422Button, C423Button, C424Button, C425Button, C426Button, C427Button, C428Button,
                C501Button, C502Button, C503Button, C504Button, C505Button, C506Button, C507Button, C408Button, C509Button, C510Button, C511Button, C512Button, C513Button, C514Button, C515Button, C516Button, C517Button, C518Button, C519Button, C520Button, C521Button, C522Button, C523Button, C524Button, C525Button, C526Button, C527Button, C528Button
            };

            // 透過度を判定する。
            if (255 == solidColorBrush.Color.A)
            {
                // 透過度が適用されていない場合

                // 選択ブラシの色が選択色一覧に存在する場合、該当する選択色ボタンにフォーカスを設定する。
                string colorCode = selectedBrush.ToString().Remove(1, 2);
                Button colorButton = ColorButtonList.FirstOrDefault(button => string.Equals(button.Tag.ToString(), colorCode));
                colorButton?.Focus();
            }
        }

        #endregion

        #region イベント

        /// <summary>
        /// カラーボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            Button targetButton = sender as Button;
            Brush brush = (Brush)BrushConverter.ConvertFromString(targetButton.Tag.ToString());
            SelectColorTextBlock.Background = brush;

            SolidColorBrush solidColorBrush = SelectColorTextBlock.Background as SolidColorBrush;
            RedValueTextBox.Text = solidColorBrush.Color.R.ToString();
            GreenValueTextBox.Text = solidColorBrush.Color.G.ToString();
            BlueValueTextBox.Text = solidColorBrush.Color.B.ToString();
            AlphaValueTextBox.Text = solidColorBrush.Color.A.ToString();

            RedSlider.Value = double.Parse(RedValueTextBox.Text);
            GreenSlider.Value = double.Parse(GreenValueTextBox.Text);
            BlueSlider.Value = double.Parse(BlueValueTextBox.Text);
            AlphaSlider.Value = double.Parse(AlphaValueTextBox.Text);
        }

        /// <summary>
        /// カラーボタンフォーカス取得処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void ColorButton_GotFocus(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Border border = button.Content as Border;
            border.BorderThickness = new Thickness(3);

            SelectColorTextBlock.Background = ((TextBlock)border.Child).Background;

            SolidColorBrush solidColorBrush = SelectColorTextBlock.Background as SolidColorBrush;
            RedValueTextBox.Text = solidColorBrush.Color.R.ToString();
            GreenValueTextBox.Text = solidColorBrush.Color.G.ToString();
            BlueValueTextBox.Text = solidColorBrush.Color.B.ToString();
            AlphaValueTextBox.Text = solidColorBrush.Color.A.ToString();

            RedSlider.Value = double.Parse(RedValueTextBox.Text);
            GreenSlider.Value = double.Parse(GreenValueTextBox.Text);
            BlueSlider.Value = double.Parse(BlueValueTextBox.Text);
            AlphaSlider.Value = double.Parse(AlphaValueTextBox.Text);
        }

        /// <summary>
        /// カラーボタンフォーカス消失処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void C11Button_LostFocus(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Border border = button.Content as Border;
            border.BorderThickness = new Thickness(1);
        }

        /// <summary>
        /// 赤スライダー・値変更処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void RedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RedValueTextBox.Text = Math.Round(RedSlider.Value, 0).ToString();
            SetSelectColorTextBlock();
        }

        /// <summary>
        /// 緑スライダー・値変更処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void GreenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GreenValueTextBox.Text = Math.Round(GreenSlider.Value, 0).ToString();
            SetSelectColorTextBlock();
        }

        /// <summary>
        /// 青スライダー・値変更処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void BlueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            BlueValueTextBox.Text = Math.Round(BlueSlider.Value, 0).ToString();
            SetSelectColorTextBlock();
        }

        /// <summary>
        /// 透過度スライダー・値変更処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void AlphaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AlphaValueTextBox.Text = Math.Round(AlphaSlider.Value, 0).ToString();
            SetSelectColorTextBlock();
        }

        /// <summary>
        /// 赤テキストボックス・フォーカス喪失処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void RedValueTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ColorValueTextBoxLostFocus(RedSlider, RedValueTextBox.Text);
        }

        /// <summary>
        /// 緑テキストボックス・フォーカス喪失処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void GreenValueTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ColorValueTextBoxLostFocus(GreenSlider, GreenValueTextBox.Text);
        }

        /// <summary>
        /// 青テキストボックス・フォーカス喪失処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void BlueValueTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ColorValueTextBoxLostFocus(BlueSlider, BlueValueTextBox.Text);
        }

        /// <summary>
        /// 透過度テキストボックス・フォーカス喪失処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void AlphaValueTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ColorValueTextBoxLostFocus(AlphaSlider, AlphaValueTextBox.Text);
        }

        /// <summary>
        /// ＯＫボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedBrush = SelectColorTextBlock.Background;
            DialogResult = true;
            Close();
        }

        /// <summary>
        /// キャンセルボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion

        #region ヘルパーメソッド

        /// <summary>
        /// 選択色テキストブロック設定処理
        /// </summary>
        private void SetSelectColorTextBlock()
        {
            bool checkFlg = true;
            foreach (TextBox colorValueTextBox in ColorValueTextBoxList)
            {
                if (int.TryParse(colorValueTextBox.Text, out int number))
                {
                    if (number < 0 || number > 255)
                    {
                        checkFlg = false;
                        break;
                    }
                }
                else
                {
                    checkFlg = false;
                    break;
                }
            }

            if (checkFlg)
            {
                SelectColorTextBlock.Background = new SolidColorBrush(
                    Color.FromArgb(
                        byte.Parse(AlphaValueTextBox.Text),
                        byte.Parse(RedValueTextBox.Text),
                        byte.Parse(GreenValueTextBox.Text),
                        byte.Parse(BlueValueTextBox.Text)));
            }
        }

        /// <summary>
        /// カラーテキストボックス・フォーカス喪失処理
        /// </summary>
        /// <param name="slider">スライダー</param>
        /// <param name="value">値</param>
        private void ColorValueTextBoxLostFocus(Slider slider, string value)
        {
            if (!string.IsNullOrWhiteSpace(value) &&
                double.TryParse(value, out double number))
            {
                if (number >= 0 && number <= 255)
                {
                    slider.Value = number;
                }
            }
        }

        #endregion
    }
}
