using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using SystemDrawing = System.Drawing;

namespace FugyunSlidePuzzle
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        #region プロパティ

        /// <summary>
        /// ピースサイズ
        /// </summary>
        private int PieceSize { get; set; }

        /// <summary>
        /// ピースリスト
        /// </summary>
        private List<Image> PieceList { get; set; } = new List<Image>();

        /// <summary>
        /// ピーステーブル
        /// </summary>
        private DataTable PieceTable { get; set; }

        /// <summary>
        /// 行列数
        /// </summary>
        private int RowColIndex { get; set; }

        /// <summary>
        /// 設定行列数
        /// </summary>
        private int SettingRowColIndex { get; set; }

        /// <summary>
        /// 初期行列数
        /// </summary>
        private int InitRowColIndex { get; set; }

        /// <summary>
        /// イメージ復元ファイルパス
        /// </summary>
        private string ImageRestoreFilePath { get; set; } = string.Empty;

        /// <summary>
        /// ピース数テキスト
        /// </summary>
        private string PieceCountText { get; set; } = string.Empty;

        /// <summary>
        /// ピース移動速度
        /// </summary>
        private double PieceMoveSpeed { get; set; }

        /// <summary>
        /// ピース移動音パス
        /// </summary>
        private string PieceMoveSoundPath { get; set; } = string.Empty;

        /// <summary>
        /// ピース移動音復元ファイルパス
        /// </summary>
        private string PieceMoveSoundRestoreFilePath { get; set; } = string.Empty;

        /// <summary>
        /// クリア音パス
        /// </summary>
        private string ClearSoundPath { get; set; } = string.Empty;

        /// <summary>
        /// クリア音復元ファイルパス
        /// </summary>
        private string ClearSoundRestoreFilePath { get; set; } = string.Empty;

        /// <summary>
        /// 設定保存復元ファイルパス
        /// </summary>
        private string SettingSaveRestoreFilePath { get; set; } = string.Empty;

        /// <summary>
        /// 設定読み込み復元ファイルパス
        /// </summary>
        private string SettingReadRestoreFilePath { get; set; } = string.Empty;

        /// <summary>
        /// ピース配置設定保存復元ファイルパス
        /// </summary>
        private string PiecePlacementSettingSaveRestoreFilePath { get; set; } = string.Empty;

        /// <summary>
        /// ピース配置設定読み込み復元ファイルパス
        /// </summary>
        private string PiecePlacementSettingReadRestoreFilePath { get; set; } = string.Empty;

        /// <summary>
        /// 操作履歴・初期配置保存復元ファイルパス
        /// </summary>
        private string OperationHistoryInitSaveRestoreFilePath { get; set; } = string.Empty;

        /// <summary>
        /// ビットマップイメージ読み込みフラグ
        /// （true：エラー無し・false：読み込みエラー）
        /// </summary>
        private bool BitmapImageReadFlg { get; set; } = true;

        /// <summary>
        /// 移動フラグ
        /// （true：移動中・false：未移動）
        /// </summary>
        private bool MoveFlg { get; set; } = false;

        /// <summary>
        /// クリアフラグ
        /// （true：クリア・false：未クリア）
        /// </summary>
        private bool ClearFlg { get; set; } = false;

        /// <summary>
        /// 操作履歴番号
        /// </summary>
        private int OperationHistoryNo { get; set; }

        /// <summary>
        /// 操作履歴情報リスト
        /// </summary>
        private List<OperationHistoryInfo> OperationHistoryInfoList { get; set; } = new List<OperationHistoryInfo>();

        /// <summary>
        /// 秒
        /// </summary>
        private int Seconds { get; set; }

        /// <summary>
        /// 時間更新タイマー
        /// </summary>
        private DispatcherTimer TimeUpdateTimer { get; set; } = new DispatcherTimer(DispatcherPriority.Normal);

        /// <summary>
        /// ローテートフラグ
        /// （true：正回転・false：逆回転）
        /// </summary>
        private bool RotateFlg { get; set; } = true;

        /// <summary>
        /// ピース移動音メディアプレイヤー
        /// </summary>
        private MediaPlayer PieceMoveSoundPlayer { get; set; } = new MediaPlayer();

        /// <summary>
        /// クリア音メディアプレイヤー
        /// </summary>
        private MediaPlayer ClearSoundPlayer { get; set; } = new MediaPlayer();

        /// <summary>
        /// 完成率ストーリーボード
        /// </summary>
        private Storyboard CompletionRateStoryboard { get; set; }

        /// <summary>
        /// 完成率アニメーションフラグ
        /// （true：実行中・false：停止中）
        /// </summary>
        private bool CompletionRateAnimationFlg { get; set; }

        /// <summary>
        /// 設定テキストブロックストーリーボード
        /// </summary>
        private Storyboard SettingTextBlockStoryboard { get; set; }

        /// <summary>
        /// ピース配置設定エラーテキストブロックストーリーボード
        /// </summary>
        private Storyboard PiecePlacementSettingErrorTextBlockStoryboard { get; set; }

        /// <summary>
        /// 読み込み番号リスト
        /// </summary>
        private List<string> ReadNumberList { get; set; } = new List<string>();

        /// <summary>
        /// ピース配置データグリッドセル値データテーブル
        /// </summary>
        private DataTable PiecePlacementSettingDataGridCellValueDataTable { get; set; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            PieceCountComboBox.SelectedIndex = 0;
            PieceSpeedComboBox.SelectedIndex = 3;
            FontSizeComboBox.SelectedIndex = 10;
            PieceSizeComboBox.SelectedIndex = 5;
            SelectTabItemComboBox.SelectedIndex = 0;
            PiecePlacementPieceCountComboBox.SelectedIndex = 0;

            NewGameButton.Focus();

            // 完成率テキストブロックのアニメーションを設定する。
            // 移動
            DoubleAnimation moveAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(3),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                From = Canvas.GetLeft(CompletionRateTextBlock),
                To = 445
            };

            // ストーリーボードを生成し、アニメーションの追加する。
            CompletionRateStoryboard = new Storyboard();
            CompletionRateStoryboard.Children.Add(moveAnimation);
            Storyboard.SetTarget(moveAnimation, CompletionRateTextBlock);
            Storyboard.SetTargetProperty(moveAnimation, new PropertyPath(Canvas.LeftProperty));

            // 文字色変更
            ColorAnimation colorAnimation = new ColorAnimation
            {
                Duration = TimeSpan.FromSeconds(3),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                From = Colors.Black,
                To = Colors.DarkViolet
            };
            Storyboard.SetTarget(colorAnimation, CompletionRateTextBlock);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(TextBlock.Foreground).(SolidColorBrush.Color)"));
            CompletionRateStoryboard.Children.Add(colorAnimation);

            // 新規開始押下処理を呼び出す。
            NewGameButton_Click(null, null);

            // 選択タブを、【設定】に戻す。
            SettingTabControl.SelectedIndex = 0;

            // ピース数コンボボックス選択後処理を呼び出す。
            PiecePlacementPieceCountComboBox_SelectionChanged(null, null);

            // 設定テキストブロックストーリーボードを設定する。
            SettingTextBlockStoryboard = new Storyboard();
            DoubleAnimation settingTextBlockAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                From = 20,
                To = 25
            };
            Storyboard.SetTarget(settingTextBlockAnimation, SettingTextBlock);
            Storyboard.SetTargetProperty(settingTextBlockAnimation, new PropertyPath(TextBlock.FontSizeProperty));
            SettingTextBlockStoryboard.Children.Add(settingTextBlockAnimation);
            SettingTextBlockStoryboard.Begin();
        }

        #endregion

        #region イベント

        /// <summary>
        /// ウィンドウ・キー押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (KeyDownCheckBox.IsChecked == true)
            {
                int blankRowIndex = 0,
                    blankColIndex = 0,
                    pieceRowIndex = 0,
                    pieceColIndex = 0,
                    directionValue = 0;

                // 押下されたキーを判定する。
                switch (e.Key)
                {   
                    case Key.Up:
                    case Key.Down:
                    case Key.Left:
                    case Key.Right:
                        if (ClearFlg || MoveFlg)
                        {
                            e.Handled = true;
                            break;
                        }

                        // 移動先位置を取得・保持する。
                        for (int rowIndex = 0; rowIndex < PieceTable.Rows.Count; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < PieceTable.Columns.Count; colIndex++)
                            {
                                if (string.IsNullOrEmpty(PieceTable.Rows[rowIndex][colIndex].ToString()))
                                {
                                    blankRowIndex = rowIndex;
                                    blankColIndex = colIndex;
                                    break;
                                }
                            }
                        }

                        Image image = null;

                        // 移動対象ピースを取得・保持する。
                        // 押下されたキーを判定する。
                        switch (e.Key)
                        {
                            case Key.Up:
                            case Key.Down:
                                if (e.Key == Key.Up)
                                {
                                    pieceRowIndex = blankRowIndex + 1;
                                }
                                else
                                {
                                    pieceRowIndex = blankRowIndex - 1;
                                    directionValue = 1;
                                }

                                if (pieceRowIndex >= 0 && pieceRowIndex < PieceTable.Rows.Count)
                                {
                                    image = PieceList.First(piece => string.Equals(piece.Tag.ToString(), PieceTable.Rows[pieceRowIndex][blankColIndex].ToString()));
                                    pieceColIndex = blankColIndex;
                                }

                                break;

                            case Key.Left:
                            case Key.Right:
                                if (e.Key == Key.Left)
                                {
                                    pieceColIndex = blankColIndex + 1;
                                    directionValue = 2;
                                }
                                else
                                {
                                    pieceColIndex = blankColIndex - 1;
                                    directionValue = 3;
                                }

                                if (pieceColIndex >= 0 && pieceColIndex < PieceTable.Columns.Count)
                                {
                                    image = PieceList.First(piece => string.Equals(piece.Tag.ToString(), PieceTable.Rows[blankRowIndex][pieceColIndex].ToString()));
                                    pieceRowIndex = blankRowIndex;
                                }

                                break;
                        }

                        // イメージの有無を判定する。
                        if (null != image)
                        {
                            if (ClearFlg || MoveFlg)
                            {
                                return;
                            }

                            // 時間更新タイマーの起動状態を判定する。
                            if (!TimeUpdateTimer.IsEnabled)
                            {
                                // 起動していない場合、起動する。
                                TimeUpdateTimer.Start();
                            }

                            // 完成率アニメーションフラグを判定する。
                            if (!CompletionRateAnimationFlg)
                            {
                                // 実行中の場合
                                CompletionRateStoryboard.Begin();
                                CompletionRateAnimationFlg = true;
                            }

                            // アニメーションを設定する。
                            DoubleAnimation animation = new DoubleAnimation
                            {
                                Duration = TimeSpan.FromMilliseconds(PieceMoveSpeed)
                            };

                            int setValue = int.Parse(image.Tag.ToString());

                            // 値を設定する。
                            PieceTable.Rows[blankRowIndex][blankColIndex] = setValue;
                            PieceTable.Rows[pieceRowIndex][pieceColIndex] = string.Empty;

                            // 方向値を判定する。
                            if (directionValue == 0)
                            {
                                // 上
                                animation.From = Canvas.GetTop(image);
                                animation.To = Canvas.GetTop(image) - PieceSize;
                            }
                            else if (directionValue == 1)
                            {
                                // 下
                                animation.From = Canvas.GetTop(image);
                                animation.To = Canvas.GetTop(image) + PieceSize;
                            }
                            else if (directionValue == 2)
                            {
                                // 左
                                animation.From = Canvas.GetLeft(image);
                                animation.To = Canvas.GetLeft(image) - PieceSize;
                            }
                            else if (directionValue == 3)
                            {
                                // 右
                                animation.From = Canvas.GetLeft(image);
                                animation.To = Canvas.GetLeft(image) + PieceSize;
                            }

                            // 移動フラグに、【移動中】を設定する。
                            MoveFlg = true;

                            // ピーステーブルチェック処理を呼び出し、結果を設定する。
                            ClearFlg = PieceTableCheck();

                            // ストーリーボードを生成し、アニメーションの追加する。
                            Storyboard storyboard = new Storyboard();
                            storyboard.Children.Add(animation);
                            Storyboard.SetTarget(animation, image);

                            if (directionValue == 0 || directionValue == 1)
                            {
                                Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));
                            }
                            else
                            {
                                Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));
                            }

                            // ストーリーボード完了後処理を設定する。
                            storyboard.Completed += Storyboard_Completed;

                            // 音楽ファイルの有無を判定する。
                            if (!string.IsNullOrWhiteSpace(PieceMoveSoundPath) && File.Exists(PieceMoveSoundPath))
                            {
                                // 存在する場合、音楽ファイルを開き、再生する。
                                // （再生する度に開かないと、音楽が再生されないため、ここで音楽ファイルを開いている。）
                                PieceMoveSoundPlayer.Open(new Uri(PieceMoveSoundPath, UriKind.Absolute));
                                PieceMoveSoundPlayer.Play();
                            }

                            // 操作履歴出力処理を呼び出す。
                            OutputOperationHistory(false, setValue, directionValue);

                            // 操作履歴情報を設定する。
                            OperationHistoryInfoList.Add(new OperationHistoryInfo(setValue, directionValue, image));

                            // 完成率設定処理を呼び出す。
                            SetCompletionRate();

                            // ストーリーボードを開始する。
                            storyboard.Begin();
                        }

                        e.Handled = true;
                        break;
                    case Key.F1:
                        NewGameButton_Click(null, null);
                        e.Handled = true;
                        break;
                    case Key.Back:
                        RedoButton_Click(null, null);
                        e.Handled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// グリッドスプリッター変更処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void GridSplitter_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            // ウィンドウステータスを判定し、値を設定する。
            double currentWidth = WindowState == WindowState.Maximized ? SystemParameters.WorkArea.Width : ActualWidth;

            if (currentWidth > 200)
            {
                // 右列の最大横幅を設定する。
                RightColumnDefinition.MaxWidth = currentWidth - 200;
            }
        }

        /// <summary>
        /// 新規開始押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            // 選択項目を基に処理を分岐する。
            if (0 == PieceCountComboBox.SelectedIndex)
            {
                RowColIndex = 3;
            }
            else if (1 == PieceCountComboBox.SelectedIndex)
            {
                RowColIndex = 4;
            }
            else if (2 == PieceCountComboBox.SelectedIndex)
            {
                RowColIndex = 5;
            }
            else if (3 == PieceCountComboBox.SelectedIndex)
            {
                RowColIndex = 6;
            }
            else if (4 == PieceCountComboBox.SelectedIndex)
            {
                RowColIndex = 7;
            }
            else if (5 == PieceCountComboBox.SelectedIndex)
            {
                RowColIndex = 8;
            }

            List<int> numberList;
            int lastNumber = RowColIndex * RowColIndex;
            Random random = new Random();

            // クリア出来る配置になるまで、処理を繰り返す。
            while (true)
            {
                // 最終番号を除いた内容をランダムにした番号リストを生成する。
                numberList = Enumerable.Range(1, lastNumber - 1).OrderBy(_ => random.Next()).ToList();
                numberList.Add(lastNumber);

                // 定理判定処理を呼び出し、戻り値を判定する。
                if (TheoremJudgment(RowColIndex, numberList))
                {
                    // クリア可能配置の場合
                    break;
                }
            }

            // 選択タブコンボボックスの選択位置を判定する。
            if (SelectTabItemComboBox.SelectedIndex == 1)
            {
                SettingTabControl.SelectedIndex = 2;
            }
            else if (SelectTabItemComboBox.SelectedIndex == 2)
            {
                SettingTabControl.SelectedIndex = 3;
            }

            // ピースリスト設定処理を呼び出す。
            SetPieceList(RowColIndex, numberList);
        }

        /// <summary>
        /// 元に戻すボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!OperationHistoryInfoList.Any())
            {
                return;
            }

            if (ClearFlg || MoveFlg)
            {
                return;
            }

            // 移動フラグに、【移動中】を設定する。
            MoveFlg = true;

            OperationHistoryInfo info = OperationHistoryInfoList.Last();

            // 対象番号を保持する。
            string searchNumber = info.PieceNumber.ToString();

            int targetRowIndex = 0,
                targetColIndex = 0,
                rowIndex = 0,
                colIndex = 0,
                directionValue = 0;
            bool judgeFlg = false;

            // 対象行列位置を取得・保持する。
            for (rowIndex = 0; rowIndex < PieceTable.Rows.Count; rowIndex++)
            {
                for (colIndex = 0; colIndex < PieceTable.Columns.Count; colIndex++)
                {
                    if (string.Equals(PieceTable.Rows[rowIndex][colIndex].ToString(), searchNumber))
                    {
                        targetRowIndex = rowIndex;
                        targetColIndex = colIndex;
                        judgeFlg = true;
                        break;
                    }
                }

                if (judgeFlg)
                {
                    break;
                }
            }

            // アニメーションを設定する。
            DoubleAnimation animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromMilliseconds(PieceMoveSpeed)
            };

            judgeFlg = true;

            // 移動値を判定する。
            if (info.DirectionValue == 0)
            {
                // 上の場合
                // （下に移動させる。）
                rowIndex = targetRowIndex + 1;
                PieceTable.Rows[rowIndex][targetColIndex] = searchNumber;
                PieceTable.Rows[targetRowIndex][targetColIndex] = string.Empty;
                animation.From = Canvas.GetTop(info.TargetImage);
                animation.To = Canvas.GetTop(info.TargetImage) + PieceSize;
                directionValue = 1;
            }
            else if (info.DirectionValue == 1)
            {
                // 下の場合
                // （上に移動させる。）
                rowIndex = targetRowIndex - 1;
                PieceTable.Rows[rowIndex][targetColIndex] = searchNumber;
                PieceTable.Rows[targetRowIndex][targetColIndex] = string.Empty;
                animation.From = Canvas.GetTop(info.TargetImage);
                animation.To = Canvas.GetTop(info.TargetImage) - PieceSize;
                directionValue = 0;
            }
            else if (info.DirectionValue == 2)
            {
                // 左の場合
                // （右に移動させる。）
                colIndex = targetColIndex + 1;
                PieceTable.Rows[targetRowIndex][colIndex] = searchNumber;
                PieceTable.Rows[targetRowIndex][targetColIndex] = string.Empty;
                animation.From = Canvas.GetLeft(info.TargetImage);
                animation.To = Canvas.GetLeft(info.TargetImage) + PieceSize;
                directionValue = 3;
                judgeFlg = false;
            }
            else if (info.DirectionValue == 3)
            {
                // 右の場合
                // （左に移動させる。）
                colIndex = targetColIndex - 1;
                PieceTable.Rows[targetRowIndex][colIndex] = searchNumber;
                PieceTable.Rows[targetRowIndex][targetColIndex] = string.Empty;
                animation.From = Canvas.GetLeft(info.TargetImage);
                animation.To = Canvas.GetLeft(info.TargetImage) - PieceSize;
                directionValue = 2;
                judgeFlg = false;
            }

            // ストーリーボードを生成し、アニメーションの追加する。
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, info.TargetImage);

            // 判定フラグを判定する。
            if (judgeFlg)
            {
                Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));
            }
            else
            {
                Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));
            }

            // ストーリーボード完了後処理を設定する。
            storyboard.Completed += Storyboard_Completed;

            // 操作履歴出力処理を呼び出す。
            OutputOperationHistory(true, int.Parse(searchNumber), directionValue);

            // 最新の操作履歴情報を削除する。
            OperationHistoryInfoList.RemoveAt(OperationHistoryInfoList.Count - 1);

            // ストーリーボードを開始する。
            storyboard.Begin();
        }

        /// <summary>
        /// 指定ピースを点滅ボタンを押下する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlinkingButton_Click(object sender, RoutedEventArgs e)
        {
            // 対象イメージを取得し、存在する場合、点滅させる。
            if (LogicalTreeHelper.FindLogicalNode(this, string.Concat("Image", ConvertNumberHalf(PieceNumberComboBox.Text))) is Image image)
            {
                DoubleAnimation blinkAnimation = new DoubleAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.5),
                    AutoReverse = true,
                    RepeatBehavior = new RepeatBehavior(3),
                    From = 1.0,
                    To = 0.0
                };
                image.BeginAnimation(OpacityProperty, blinkAnimation);
            }
        }

        /// <summary>
        /// 時間更新タイマー間隔処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void TimeUpdateTimer_Tick(object sender, EventArgs e)
        {
            Seconds++;

            if (Seconds < 60)
            {
                TimeTextBlock.Text = $"{ConvertNumberWide(Seconds)}秒";
            }
            else
            {
                TimeTextBlock.Text = $"{ConvertNumberWide(Seconds / 60)}分{ConvertNumberWide(Seconds % 60)}秒";
            }

            if (ConvertNumberWide(Seconds).EndsWith("０"))
            {
                double toValue = 360;
                if (RotateFlg)
                {
                    RotateFlg = false;
                }
                else
                {
                    RotateFlg = true;
                    toValue = -360;
                }

                // 回転アニメーションを設定し、開始する。
                RotateTransform rotateTransform = new RotateTransform();
                TimeTextBlock.RenderTransform = rotateTransform;
                DoubleAnimation rotateAnimation = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(1),
                    From = 0,
                    To = toValue
                };
                rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
            }
        }

        /// <summary>
        /// キー押下チェックボックス・チェック後処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void KeyDownCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            NewGameButton.Content = "新規開始（Ｆ１）";
            NewGameButton.Width = 180;
            RedoButton.Content = "元に戻す（ＢＫＳＰ）";
            RedoButton.Width = 180;
            Canvas.SetLeft(RedoButton, 220);
            Canvas.SetLeft(TimeTextBlock, 442);
            PiecePlacementTextBlock.Text = "◆ピース配置（矢印キー・ＢＫＳＰキーが無効）";
            OperationHistoryTextBlock.Text = "◆操作履歴（矢印キー・ＢＫＳＰキーが無効）";
        }

        /// <summary>
        /// キー押下チェックボックス・非チェック後処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void KeyDownCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            NewGameButton.Content = "新規開始";
            NewGameButton.Width = 180;
            RedoButton.Content = "元に戻す";
            RedoButton.Width = 180;
            Canvas.SetLeft(RedoButton, 220);
            Canvas.SetLeft(TimeTextBlock, 442);
            PiecePlacementTextBlock.Text = "◆ピース配置";
            OperationHistoryTextBlock.Text = "◆操作履歴";
        }

        /// <summary>
        /// ピース画像・マウス左ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void PieceImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ClearFlg || MoveFlg)
            {
                return;
            }

            // 時間更新タイマーの起動状態を判定する。
            if (!TimeUpdateTimer.IsEnabled)
            {
                // 起動していない場合、起動する。
                TimeUpdateTimer.Start();
            }

            // 完成率アニメーションフラグを判定する。
            if (!CompletionRateAnimationFlg)
            {
                // 実行中の場合
                CompletionRateStoryboard.Begin();
                CompletionRateAnimationFlg = true;
            }

            Image image = (Image)sender;

            // 対象番号を保持する。
            string searchNumber = image.Tag.ToString(), changeNumber;

            int targetRowIndex = 0,
                targetColIndex = 0,
                rowIndex = 0,
                colIndex = 0,
                directionValue = 0;
            bool judgeFlg = false;

            // 対象行列位置を取得・保持する。
            for (rowIndex = 0; rowIndex < PieceTable.Rows.Count; rowIndex++)
            {
                for (colIndex = 0; colIndex < PieceTable.Columns.Count; colIndex++)
                {
                    if (string.Equals(PieceTable.Rows[rowIndex][colIndex].ToString(), searchNumber))
                    {
                        targetRowIndex = rowIndex;
                        targetColIndex = colIndex;
                        judgeFlg = true;
                        break;
                    }
                }

                if (judgeFlg)
                {
                    break;
                }
            }

            // アニメーションを設定する。
            DoubleAnimation animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromMilliseconds(PieceMoveSpeed)
            };

            // 移動先を判定する。
            bool movableFlg = false;
            judgeFlg = true;

            // 上
            rowIndex = targetRowIndex - 1;
            if (rowIndex >= 0 && rowIndex < PieceTable.Rows.Count)
            {
                changeNumber = PieceTable.Rows[rowIndex][targetColIndex].ToString();
                if (string.IsNullOrEmpty(changeNumber))
                {
                    PieceTable.Rows[rowIndex][targetColIndex] = searchNumber;
                    PieceTable.Rows[targetRowIndex][targetColIndex] = string.Empty;
                    animation.From = Canvas.GetTop(image);
                    animation.To = Canvas.GetTop(image) - PieceSize;
                    movableFlg = true;
                }
            }

            // 下
            if (!movableFlg)
            {
                rowIndex = targetRowIndex + 1;
                if (rowIndex >= 0 && rowIndex < PieceTable.Rows.Count)
                {
                    changeNumber = PieceTable.Rows[rowIndex][targetColIndex].ToString();
                    if (string.IsNullOrEmpty(changeNumber))
                    {
                        PieceTable.Rows[rowIndex][targetColIndex] = searchNumber;
                        PieceTable.Rows[targetRowIndex][targetColIndex] = string.Empty;
                        animation.From = Canvas.GetTop(image);
                        animation.To = Canvas.GetTop(image) + PieceSize;
                        directionValue = 1;
                        movableFlg = true;
                    }
                }
            }

            // 左
            if (!movableFlg)
            {
                colIndex = targetColIndex - 1;
                if (colIndex >= 0 && colIndex < PieceTable.Columns.Count)
                {
                    changeNumber = PieceTable.Rows[targetRowIndex][colIndex].ToString();
                    if (string.IsNullOrEmpty(changeNumber))
                    {
                        PieceTable.Rows[targetRowIndex][colIndex] = searchNumber;
                        PieceTable.Rows[targetRowIndex][targetColIndex] = string.Empty;
                        animation.From = Canvas.GetLeft(image);
                        animation.To = Canvas.GetLeft(image) - PieceSize;
                        directionValue = 2;
                        movableFlg = true;
                        judgeFlg = false;
                    }
                }
            }

            // 右
            if (!movableFlg)
            {
                colIndex = targetColIndex + 1;
                if (colIndex >= 0 && colIndex < PieceTable.Columns.Count)
                {
                    changeNumber = PieceTable.Rows[targetRowIndex][colIndex].ToString();
                    if (string.IsNullOrEmpty(changeNumber))
                    {
                        PieceTable.Rows[targetRowIndex][colIndex] = searchNumber;
                        PieceTable.Rows[targetRowIndex][targetColIndex] = string.Empty;
                        animation.From = Canvas.GetLeft(image);
                        animation.To = Canvas.GetLeft(image) + PieceSize;
                        directionValue = 3;
                        movableFlg = true;
                        judgeFlg = false;
                    }
                }
            }

            // 移動可能フラグを判定する。
            if (!movableFlg)
            {
                // 移動不可の場合、処理を終了する。
                return;
            }

            // 移動フラグに、【移動中】を設定する。
            MoveFlg = true;

            // ピーステーブルチェック処理を呼び出し、結果を設定する。
            ClearFlg = PieceTableCheck();

            // ストーリーボードを生成し、アニメーションの追加する。
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, image);

            // 判定フラグを判定する。
            if (judgeFlg)
            {
                Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));
            }
            else
            {
                Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));
            }

            // ストーリーボード完了後処理を設定する。
            storyboard.Completed += Storyboard_Completed;

            // 音楽ファイルの有無を判定する。
            if (!string.IsNullOrWhiteSpace(PieceMoveSoundPath) && File.Exists(PieceMoveSoundPath))
            {
                // 存在する場合、音楽ファイルを開き、再生する。
                // （再生する度に開かないと、音楽が再生されないため、ここで音楽ファイルを開いている。）
                PieceMoveSoundPlayer.Open(new Uri(PieceMoveSoundPath, UriKind.Absolute));
                PieceMoveSoundPlayer.Play();
            }

            // 操作履歴出力処理を呼び出す。
            OutputOperationHistory(false, int.Parse(searchNumber), directionValue);

            // 操作履歴情報を設定する。
            OperationHistoryInfoList.Add(new OperationHistoryInfo(int.Parse(searchNumber), directionValue, image));

            // 完成率設定処理を呼び出す。
            SetCompletionRate();

            // ストーリーボードを開始する。
            storyboard.Begin();
        }

        /// <summary>
        /// ストーリーボード完了後処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            // クリアフラグを判定する。
            if (ClearFlg)
            {
                // クリアの場合

                // 時間更新タイマーを停止させる。
                TimeUpdateTimer.Stop();

                // 完成率ストーリーボードを一時停止させる。
                CompletionRateStoryboard.Pause();

                // 操作履歴にクリア時間を追加する。
                OperationHistoryTextBox.Text = string.Concat(
                    OperationHistoryTextBox.Text,
                    Environment.NewLine,
                    "クリア時間：",
                    TimeTextBlock.Text);
                OperationHistoryTextBox.ScrollToEnd();

                // ピースを削除する。
                PieceList.ForEach(piece => PuzzleCanvas.Children.Remove(piece));

                // Imageを生成する。
                Image image = new Image
                {
                    Name = "ClearImage",
                    Source = PuzzleImage.Source,
                    Width = PuzzleImage.Width,
                    Height = PuzzleImage.Height
                };

                // 光彩効果を生成する。
                DropShadowEffect glowEffect = new DropShadowEffect
                {
                    Color = Colors.Blue,
                    // ぼかし半径
                    BlurRadius = 20,
                    // 影の深さを0にして光彩する。
                    ShadowDepth = 0,
                    // 光彩の不透明度
                    Opacity = 0.8
                };

                // Imageに光彩効果を設定する。
                image.Effect = glowEffect;

                // Canvasに描画する。
                Canvas.SetLeft(image, Const.MARGIN_LEFT);
                Canvas.SetTop(image, Const.MARGIN_TOP);
                PuzzleCanvas.Children.Add(image);

                // 音楽ファイルの有無を判定する。
                if (!string.IsNullOrWhiteSpace(ClearSoundPath) && File.Exists(ClearSoundPath))
                {
                    // 存在する場合、音楽ファイルを開き、再生する。
                    // （再生する度に開かないと、音楽が再生されないため、ここで音楽ファイルを開いている。）
                    ClearSoundPlayer.Open(new Uri(ClearSoundPath, UriKind.Absolute));
                    ClearSoundPlayer.Play();
                }

                // 中心点を設定する。
                image.RenderTransform = new RotateTransform(0, image.Width / 2, image.Height / 2);

                // 点滅アニメーションを設定する。
                DoubleAnimation blinkAnimation = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(0.5),
                    AutoReverse = true,
                    RepeatBehavior = new RepeatBehavior(3),
                    From = 1,
                    To = 0
                };
                Storyboard storyboard = new Storyboard();
                Storyboard.SetTarget(blinkAnimation, image);
                Storyboard.SetTargetProperty(blinkAnimation, new PropertyPath(OpacityProperty));
                storyboard.Children.Add(blinkAnimation);

                // 回転アニメーションを設定する。
                DoubleAnimation rotateAnimation = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(1),
                    BeginTime = TimeSpan.FromSeconds(3),
                    From = 0,
                    To = 360
                };
                Storyboard.SetTarget(rotateAnimation, image);
                Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
                storyboard.Children.Add(rotateAnimation);

                // 点滅アニメーションを設定する。
                DoubleAnimation blinkAnimationAgain = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(0.5),
                    AutoReverse = true,
                    RepeatBehavior = new RepeatBehavior(3),
                    BeginTime = TimeSpan.FromSeconds(4),
                    From = 1,
                    To = 0
                };
                Storyboard.SetTarget(blinkAnimationAgain, image);
                Storyboard.SetTargetProperty(blinkAnimationAgain, new PropertyPath(OpacityProperty));
                storyboard.Children.Add(blinkAnimationAgain);

                // （逆）回転アニメーションを設定する。
                DoubleAnimation reverseRotateAnimation = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(1),
                    BeginTime = TimeSpan.FromSeconds(7),
                    From = 360,
                    To = 0
                };
                Storyboard.SetTarget(reverseRotateAnimation, image);
                Storyboard.SetTargetProperty(reverseRotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
                storyboard.Children.Add(reverseRotateAnimation);

                // アニメーションを開始する。
                storyboard.Begin();
            }

            // 移動フラグに、【未移動】を設定する。
            MoveFlg = false;
        }

        /// <summary>
        /// 停止ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void SettingTextBlockStopButton_Click(object sender, RoutedEventArgs e)
        {
            SettingTextBlockStoryboard.Stop();
        }

        /// <summary>
        /// 画像選択ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void ImageSelectButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "パズル画像を開く",
                FileName = string.IsNullOrEmpty(ImageRestoreFilePath) ? string.Empty : System.IO.Path.GetFileName(ImageRestoreFilePath),
                Filter = "画像ファイル(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp",
                InitialDirectory = string.IsNullOrEmpty(ImageRestoreFilePath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : System.IO.Path.GetDirectoryName(ImageRestoreFilePath)
            };
            if (openFileDialog.ShowDialog(this) == true)
            {
                ImagePathTextBox.Text = openFileDialog.FileName;
                ImagePathTextBox.Focus();
                ImagePathTextBox.SelectionStart = ImagePathTextBox.Text.Length;
                ImageRestoreFilePath = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// 文字色設定ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void FontColorSettingButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker(FontColorSampleTextBlock.Foreground)
            {
                Owner = this,
                Title = "文字色を選択"
            };
            if (colorPicker.ShowDialog() == true)
            {
                FontColorSampleTextBlock.Foreground = colorPicker.SelectedBrush;
            }
        }

        /// <summary>
        /// 線色設定ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void LineColorSettingButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker(LineColorSampleTextBlock.Foreground)
            {
                Owner = this,
                Title = "線色を選択"
            };
            if (colorPicker.ShowDialog() == true)
            {
                LineColorSampleTextBlock.Foreground = colorPicker.SelectedBrush;
            }
        }

        /// <summary>
        /// 背景色設定ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void BackColorSettingButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker(BackgroundSampleTextBlock.Foreground)
            {
                Owner = this,
                Title = "背景色を設定"
            };
            if (colorPicker.ShowDialog() == true)
            {
                BackgroundSampleTextBlock.Foreground = colorPicker.SelectedBrush;
            }
        }

        /// <summary>
        /// ピース移動音選択ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void PieceMoveSoundSelectButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "ピース移動音を開く",
                FileName = string.IsNullOrEmpty(PieceMoveSoundRestoreFilePath) ? string.Empty : System.IO.Path.GetFileName(PieceMoveSoundRestoreFilePath),
                Filter = "音楽ファイル(*.wav;*.mp3)|*.wav;*.mp3",
                InitialDirectory = string.IsNullOrEmpty(PieceMoveSoundRestoreFilePath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : System.IO.Path.GetDirectoryName(PieceMoveSoundRestoreFilePath)
            };
            if (openFileDialog.ShowDialog(this) == true)
            {
                PieceMoveSoundPathTextBox.Text = openFileDialog.FileName;
                PieceMoveSoundPathTextBox.Focus();
                PieceMoveSoundPathTextBox.SelectionStart = PieceMoveSoundPathTextBox.Text.Length;
                PieceMoveSoundRestoreFilePath = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// クリア音選択ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void ClearSoundSelectButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "クリア音を開く",
                FileName = string.IsNullOrEmpty(ClearSoundRestoreFilePath) ? string.Empty : System.IO.Path.GetFileName(ClearSoundRestoreFilePath),
                Filter = "音楽ファイル(*.wav;*.mp3)|*.wav;*.mp3",
                InitialDirectory = string.IsNullOrEmpty(ClearSoundRestoreFilePath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : System.IO.Path.GetDirectoryName(ClearSoundRestoreFilePath)
            };
            if (openFileDialog.ShowDialog(this) == true)
            {
                ClearSoundPathTextBox.Text = openFileDialog.FileName;
                ClearSoundPathTextBox.Focus();
                ClearSoundPathTextBox.SelectionStart = ClearSoundPathTextBox.Text.Length;
                ClearSoundRestoreFilePath = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// 設定を保存ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void SettingSaveButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox msgBox = new CustomMessageBox() { Owner = this };

            try
            {
                var SaveSettingFileDialog = new SaveFileDialog
                {
                    Title = "設定を保存",
                    DefaultExt = "txt",
                    FileName = string.IsNullOrEmpty(SettingSaveRestoreFilePath) ? "ふぎゅんスライドパズル設定.txt" : System.IO.Path.GetFileName(SettingSaveRestoreFilePath),
                    Filter = "テキストファイル (*.txt)|*.txt",
                    InitialDirectory = string.IsNullOrEmpty(SettingSaveRestoreFilePath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : System.IO.Path.GetDirectoryName(SettingSaveRestoreFilePath)
                };
                if (SaveSettingFileDialog.ShowDialog(this) == true)
                {
                    SettingSaveRestoreFilePath = SaveSettingFileDialog.FileName;

                    // 各色を保持する。
                    Color fontColor = ((SolidColorBrush)FontColorSampleTextBlock.Foreground).Color,
                        lineColor = ((SolidColorBrush)LineColorSampleTextBlock.Foreground).Color,
                        backColor = ((SolidColorBrush)BackgroundSampleTextBlock.Foreground).Color;

                    string settingText = $@"ImagePath：{ImagePathTextBox.Text}
PieceCount：{PieceCountComboBox.Text}
PieceMoveSpeed：{PieceSpeedComboBox.Text}
FontSize：{FontSizeComboBox.Text}
PieceSize：{PieceSizeComboBox.Text}
FontColorR：{fontColor.R}
FontColorG：{fontColor.G}
FontColorB：{fontColor.B}
FontColorA：{fontColor.A}
LineColorR：{lineColor.R}
LineColorG：{lineColor.G}
LineColorB：{lineColor.B}
LineColorA：{lineColor.A}
BackColorR：{backColor.R}
BackColorG：{backColor.G}
BackColorB：{backColor.B}
BackColorA：{backColor.A}
PieceMoveSoundPath：{PieceMoveSoundPathTextBox.Text}
ClearSoundPath：{ClearSoundPathTextBox.Text}
NumberShow：{(NumberShowCheckBox.IsChecked == true ? 1 : 0)}
SelectTabItem：{SelectTabItemComboBox.Text}";

                    File.WriteAllText(SaveSettingFileDialog.FileName, settingText, Encoding.UTF8);

                    msgBox.Title = "設定保存完了";
                    msgBox.MessageBoxSetting(
                        "設定を保存しました。",
                        0,
                        Const.ButtonTextListOkOnly,
                        1,
                        1);
                    msgBox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                msgBox.MessageBoxSetting(
                    ex.Message,
                    1,
                    Const.ButtonTextListOkOnly,
                    1,
                    2);
                msgBox.ShowDialog();
            }
        }

        /// <summary>
        /// 設定を読み込みボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void SettingReadButton_Click(object sender, RoutedEventArgs e)
        {
            var openSettingFileDialog = new OpenFileDialog
            {
                Title = "設定を開く",
                DefaultExt = "txt",
                FileName = string.IsNullOrEmpty(SettingReadRestoreFilePath) ? "ふぎゅんスライドパズル設定.txt" : System.IO.Path.GetFileName(SettingReadRestoreFilePath),
                Filter = "テキストファイル (*.txt)|*.txt",
                InitialDirectory = string.IsNullOrEmpty(SettingReadRestoreFilePath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : System.IO.Path.GetDirectoryName(SettingReadRestoreFilePath)
            };
            if (openSettingFileDialog.ShowDialog(this) != true)
            {
                return;
            }

            CustomMessageBox msgBox = new CustomMessageBox() { Owner = this };
            SettingReadRestoreFilePath = openSettingFileDialog.FileName;
            string[] settingDataAr;

            try
            {
                // テキストファイルを読み込む。
                string settingText = File.ReadAllText(openSettingFileDialog.FileName, Encoding.UTF8);
                if (string.IsNullOrWhiteSpace(settingText))
                {
                    msgBox.MessageBoxSetting(
                        "設定を読み込めませんでした。",
                        1,
                        Const.ButtonTextListOkOnly,
                        1,
                        2);
                    msgBox.ShowDialog();
                    return;
                }
                else
                {
                    settingDataAr = settingText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch
            {
                msgBox.MessageBoxSetting(
                    "設定を読み込めませんでした。",
                    1,
                    Const.ButtonTextListOkOnly,
                    1,
                    2);
                msgBox.ShowDialog();
                settingDataAr = new string[] { };
            }

            try
            {
                string targetValue = string.Empty;

                // パズル画像
                ImagePathTextBox.Text = GetSettingValue(settingDataAr, "ImagePath：");

                // ピース数
                SetComboBoxItem(PieceCountComboBox, settingDataAr, "PieceCount：", 0);

                // ピース移動速度
                SetComboBoxItem(PieceSpeedComboBox, settingDataAr, "PieceMoveSpeed：", 3);

                // 文字サイズ
                SetComboBoxItem(FontSizeComboBox, settingDataAr, "FontSize：", 10);

                // ピースサイズ
                SetComboBoxItem(PieceSizeComboBox, settingDataAr, "PieceSize：", 5);

                // 文字色
                SetTextBlockForeground(
                    FontColorSampleTextBlock,
                    settingDataAr,
                    "FontColorR：",
                    "FontColorG：",
                    "FontColorB：",
                    "FontColorA：",
                    Brushes.Blue);

                // 線色
                SetTextBlockForeground(
                    LineColorSampleTextBlock,
                    settingDataAr,
                    "LineColorR：",
                    "LineColorG：",
                    "LineColorB：",
                    "LineColorA：",
                    Brushes.Black);

                // 背景色
                SetTextBlockForeground(
                    BackgroundSampleTextBlock,
                    settingDataAr,
                    "BackColorR：",
                    "BackColorG：",
                    "BackColorB：",
                    "BackColorA：",
                    Brushes.Azure);

                // ピース移動音
                PieceMoveSoundPathTextBox.Text = GetSettingValue(settingDataAr, "PieceMoveSoundPath：");

                // クリア音
                ClearSoundPathTextBox.Text = GetSettingValue(settingDataAr, "ClearSoundPath：");

                // 番号表示
                NumberShowCheckBox.IsChecked = true;
                targetValue = GetSettingValue(settingDataAr, "NumberShow：");

                if (string.IsNullOrEmpty(targetValue))
                {
                    NumberShowCheckBox.IsChecked = true;
                }
                else
                {
                    NumberShowCheckBox.IsChecked = int.Parse(targetValue) == 1;
                }

                // 新規開始時
                SetComboBoxItem(SelectTabItemComboBox, settingDataAr, "SelectTabItem：", 0);

                // 新規開始押下処理を呼び出す。
                NewGameButton_Click(null, null);

                msgBox.Title = "設定読み込み完了";
                msgBox.MessageBoxSetting(
                   "設定を読み込みました。",
                    0,
                    Const.ButtonTextListOkOnly,
                    1,
                    1);
                msgBox.ShowDialog();
            }
            catch (Exception ex)
            {
                msgBox.MessageBoxSetting(
                    ex.Message,
                    1,
                    Const.ButtonTextListOkOnly,
                    1,
                    2);
                msgBox.ShowDialog();
            }
        }

        /// <summary>
        /// ピース数コンボボックス選択後処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void PiecePlacementPieceCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PiecePlacementPieceCountComboBox.SelectedIndex == -1)
            {
                return;
            }

            // エラーメッセージを非表示にし、アニメーションを停止する。
            PiecePlacementSettingErrorTextBlock.Visibility = Visibility.Hidden;
            PiecePlacementSettingErrorTextBlockStoryboard?.Stop();

            // 選択項目を基に処理を分岐する。
            if (0 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                SettingRowColIndex = 3;
            }
            else if (1 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                SettingRowColIndex = 4;
            }
            else if (2 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                SettingRowColIndex = 5;
            }
            else if (3 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                SettingRowColIndex = 6;
            }
            else if (4 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                SettingRowColIndex = 7;
            }
            else if (5 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                SettingRowColIndex = 8;
            }

            // ピース配置設定データグリッドを設定する。
            DataTable piecePlacementSettingDataTable = new DataTable();

            int index,
                rowIndex,
                colIndex;

            // 列を追加する。
            for (index = 0; index < PiecePlacementSettingDataGrid.Columns.Count; index++)
            {
                // 列を追加する。
                piecePlacementSettingDataTable.Columns.Add(string.Concat("Column", index.ToString()), typeof(string));
            }
            piecePlacementSettingDataTable.Columns.Add("Value", typeof(string));

            // データを設定する。
            // 読み込み番号リストの項目の有無を判定する。
            if (ReadNumberList.Any())
            {
                // 存在する場合
                index = 0;
                for (rowIndex = 0; rowIndex < SettingRowColIndex; rowIndex++)
                {
                    piecePlacementSettingDataTable.Rows.Add();
                    for (colIndex = 0; colIndex < SettingRowColIndex; colIndex++)
                    {
                        piecePlacementSettingDataTable.Rows[rowIndex][colIndex] = int.Parse(ReadNumberList[index]);
                        index++;
                    }
                }

                // 読み込み番号リストをクリアする。
                ReadNumberList.Clear();
            }
            else
            {
                // 存在しない場合
                int value = 1;
                for (rowIndex = 0; rowIndex < SettingRowColIndex; rowIndex++)
                {
                    piecePlacementSettingDataTable.Rows.Add();
                    for (colIndex = 0; colIndex < SettingRowColIndex; colIndex++)
                    {
                        piecePlacementSettingDataTable.Rows[rowIndex][colIndex] = value;
                        value++;
                    }
                }
            }

            // 最終セルを判定するための値を設定する。
            piecePlacementSettingDataTable.Rows[SettingRowColIndex - 1][8] = SettingRowColIndex.ToString();

            // データソースを設定する。
            PiecePlacementSettingDataGrid.ItemsSource = piecePlacementSettingDataTable.DefaultView;

            // ピース配置データグリッドセル値データテーブルを設定する。
            PiecePlacementSettingDataGridCellValueDataTable = piecePlacementSettingDataTable.Copy();

            // 列サイズ・表示設定を行う。
            for (colIndex = 0; colIndex < PiecePlacementSettingDataGrid.Columns.Count; colIndex++)
            {
                PiecePlacementSettingDataGrid.Columns[colIndex].Width = 100;

                if (SettingRowColIndex > colIndex)
                {
                    PiecePlacementSettingDataGrid.Columns[colIndex].Visibility = Visibility.Visible;
                }
                else
                {
                    PiecePlacementSettingDataGrid.Columns[colIndex].Visibility = Visibility.Collapsed;
                }
            }

            // スクロール位置を初期位置にする。
            PiecePlacementSettingDataGrid.ScrollIntoView(PiecePlacementSettingDataGrid.Items[0], PiecePlacementSettingDataGrid.Columns[0]);
        }

        /// <summary>
        /// ピース配置を初期化ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void PiecePlacementInitButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox msgBox = new CustomMessageBox()
            {
                Owner = this,
                Title = "ピース配置初期化確認"
            };
            msgBox.MessageBoxSetting(
                "ピース配置を初期化しますか？",
                3,
                Const.ButtonTextListForQustion,
                2,
                1);
            msgBox.ShowDialog();
            if (msgBox.MessageBoxResult == CustomMessageBox.RETURN_BUTTON1)
            {
                // ピース数コンボボックス選択後処理を呼び出す。
                PiecePlacementPieceCountComboBox_SelectionChanged(null, null);
            }
        }

        /// <summary>
        /// スライドパズルに反映押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void SlidePuzzleReflectionButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox msgBox = new CustomMessageBox()
            {
                Owner = this,
                Title = "ピース配置反映確認"
            };
            msgBox.MessageBoxSetting(
                "ピースをスライドパズルに反映しますか？",
                3,
                Const.ButtonTextListForQustion,
                2,
                1);
            msgBox.ShowDialog();
            if (msgBox.MessageBoxResult == CustomMessageBox.RETURN_BUTTON1)
            {
                List<string> cellValueList = new List<string>();
                foreach (var item in PiecePlacementSettingDataGrid.Items)
                {
                    foreach (DataGridColumn column in PiecePlacementSettingDataGrid.Columns)
                    {
                        if (column.GetCellContent(item) is TextBlock cellContent && !string.IsNullOrEmpty(cellContent.Text))
                        {
                            cellValueList.Add(cellContent.Text);
                        }
                    }
                }

                // 選択項目を基に処理を分岐する。
                int rowColIndex = 0;
                if (0 == PiecePlacementPieceCountComboBox.SelectedIndex)
                {
                    rowColIndex = 3;
                }
                else if (1 == PiecePlacementPieceCountComboBox.SelectedIndex)
                {
                    rowColIndex = 4;
                }
                else if (2 == PiecePlacementPieceCountComboBox.SelectedIndex)
                {
                    rowColIndex = 5;
                }
                else if (3 == PiecePlacementPieceCountComboBox.SelectedIndex)
                {
                    rowColIndex = 6;
                }
                else if (4 == PiecePlacementPieceCountComboBox.SelectedIndex)
                {
                    rowColIndex = 7;
                }
                else if (5 == PiecePlacementPieceCountComboBox.SelectedIndex)
                {
                    rowColIndex = 8;
                }

                msgBox = new CustomMessageBox() { Owner = this };

                // 要素数チェック（ブランクチェック）
                int lastNumber = rowColIndex * rowColIndex;
                if (lastNumber != cellValueList.Count)
                {
                    msgBox.MessageBoxSetting(
                        "番号が未入力の箇所があります。",
                        1,
                        Const.ButtonTextListOkOnly,
                        1,
                        2);
                    msgBox.ShowDialog();
                    return;
                }

                // 数値チェック
                List<string> errorValueList = cellValueList.Where(value => !int.TryParse(value, out _)).ToList();
                if (errorValueList.Any())
                {
                    msgBox.MessageBoxSetting(
                        string.Concat(
                            "半角数値以外が入力されている箇所があります。",
                            Environment.NewLine,
                            "対象文字：",
                            string.Join("・", errorValueList)),
                        1,
                        Const.ButtonTextListOkOnly,
                        1,
                        2);
                    msgBox.ShowDialog();
                    return;
                }

                // 範囲チェック
                List<int> numberList = cellValueList.Select(cellValue => int.Parse(cellValue)).ToList();
                foreach (int value in numberList)
                {
                    if (!ValueRangeCheck(value, 1, lastNumber))
                    {
                        msgBox.MessageBoxSetting(
                            string.Concat(
                                "入力可能範囲外の数値が入力されています。",
                                Environment.NewLine,
                                "入力可能範囲：１～",
                                ConvertNumberWide(lastNumber)),
                            1,
                            Const.ButtonTextListOkOnly,
                            1,
                            2);
                        msgBox.ShowDialog();
                        return;
                    }
                }

                // 重複チェック
                if (DuplicationCheck(numberList))
                {
                    msgBox.MessageBoxSetting(
                        "重複している数値があります。",
                        1,
                        Const.ButtonTextListOkOnly,
                        1,
                        2);
                    msgBox.ShowDialog();
                    return;
                }

                // 定理チェック
                if (!TheoremJudgment(rowColIndex, numberList))
                {
                    msgBox.MessageBoxSetting(
                        string.Concat("クリア出来ない配置です。", Environment.NewLine, "数値を再入力して下さい。"),
                        1,
                        Const.ButtonTextListOkOnly,
                        1,
                        2);
                    msgBox.ShowDialog();
                    return;
                }

                // ピース数コンボボックスの選択項目を設定する。
                PieceCountComboBox.SelectedIndex = PiecePlacementPieceCountComboBox.SelectedIndex;

                // 行列数を設定する。
                RowColIndex = rowColIndex;

                // ピースリスト設定処理を呼び出す。
                SetPieceList(RowColIndex, numberList);

                msgBox.Title = "ピース配置反映完了";
                msgBox.MessageBoxSetting(
                    "ピース配置をスライドパズルに反映しました。",
                    0,
                    Const.ButtonTextListOkOnly,
                    1,
                    1);
                msgBox.ShowDialog();
            }
        }

        /// <summary>
        /// ピース配置データグリッド編集開始処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void PiecePlacementSettingDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            // 行位置・列位置を判定する。
            if (e.Row.GetIndex() == SettingRowColIndex - 1 && e.Column.DisplayIndex == SettingRowColIndex - 1)
            {
                // 最終セルの場合、処理をキャンセルする。
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ピース配置データグリッドセル編集終了処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void PiecePlacementSettingDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int rowColIndex = 0,
                editRowIndex = e.Row.GetIndex(),
                editColIndex = e.Column.DisplayIndex;

            //int rowColIndex = 0;

            // 選択項目を基に処理を分岐する。
            if (0 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                rowColIndex = 3;
            }
            else if (1 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                rowColIndex = 4;
            }
            else if (2 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                rowColIndex = 5;
            }
            else if (3 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                rowColIndex = 6;
            }
            else if (4 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                rowColIndex = 7;
            }
            else if (5 == PiecePlacementPieceCountComboBox.SelectedIndex)
            {
                rowColIndex = 8;
            }

            // ピース配置データグリッドセル値データテーブルを更新する。
            TextBox textBox = e.EditingElement as TextBox;
            PiecePlacementSettingDataGridCellValueDataTable.Rows[e.Row.GetIndex()][e.Column.DisplayIndex] = textBox.Text;

            List<string> cellValueList = new List<string>();
            for (int rowIndex = 0; rowIndex < rowColIndex; rowIndex++)
            {
                for (int colIndex = 0; colIndex < rowColIndex; colIndex++)
                {
                    cellValueList.Add(PiecePlacementSettingDataGridCellValueDataTable.Rows[rowIndex][colIndex].ToString());
                }
            }

            // アニメーションを設定する。
            void BeginAnimation()
            {
                PiecePlacementSettingErrorTextBlockStoryboard = new Storyboard();
                DoubleAnimation piecePlacementSettingErrorTextBlockAnimation = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(1),
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever,
                    From = 20,
                    To = 22
                };
                Storyboard.SetTarget(piecePlacementSettingErrorTextBlockAnimation, PiecePlacementSettingErrorTextBlock);
                Storyboard.SetTargetProperty(piecePlacementSettingErrorTextBlockAnimation, new PropertyPath(TextBlock.FontSizeProperty));
                PiecePlacementSettingErrorTextBlockStoryboard.Children.Add(piecePlacementSettingErrorTextBlockAnimation);
                PiecePlacementSettingErrorTextBlockStoryboard.Begin();
            }

            // 要素数チェック（ブランクチェック）
            int lastNumber = rowColIndex * rowColIndex;
            if (lastNumber != cellValueList.Count)
            {
                PiecePlacementSettingErrorTextBlock.Text = "番号が未入力の箇所があります。";
                PiecePlacementSettingErrorTextBlock.Visibility = Visibility.Visible;
                BeginAnimation();
                return;
            }

            // 数値チェック
            List<string> errorValueList = cellValueList.Where(value => !int.TryParse(value, out _)).ToList();
            if (errorValueList.Any())
            {
                PiecePlacementSettingErrorTextBlock.Text = "半角数値以外が入力されている箇所があります。";
                PiecePlacementSettingErrorTextBlock.Visibility = Visibility.Visible;
                BeginAnimation();
                return;
            }

            // 範囲チェック
            List<int> numberList = cellValueList.Select(cellValue => int.Parse(cellValue)).ToList();
            foreach (int value in numberList)
            {
                if (!ValueRangeCheck(value, 1, lastNumber))
                {
                    PiecePlacementSettingErrorTextBlock.Text = "入力可能範囲外の数値が入力されています。";
                    PiecePlacementSettingErrorTextBlock.Visibility = Visibility.Visible;
                    BeginAnimation();
                    return;
                }
            }

            // 重複チェック
            if (DuplicationCheck(numberList))
            {
                PiecePlacementSettingErrorTextBlock.Text = "重複している数値があります。";
                PiecePlacementSettingErrorTextBlock.Visibility = Visibility.Visible;
                BeginAnimation();
                return;
            }

            // 定理チェック
            if (!TheoremJudgment(rowColIndex, numberList))
            {
                PiecePlacementSettingErrorTextBlock.Text = "クリア出来ない配置です。";
                PiecePlacementSettingErrorTextBlock.Visibility = Visibility.Visible;
                BeginAnimation();
                return;
            }

            // エラーメッセージを非表示にし、アニメーションを停止する。
            PiecePlacementSettingErrorTextBlock.Visibility = Visibility.Hidden;
            PiecePlacementSettingErrorTextBlockStoryboard?.Stop();
        }

        /// <summary>
        /// ピース配置を保存ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void PiecePlacementSaveButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox msgBox = new CustomMessageBox() { Owner = this };

            try
            {
                var savePiecePlacementSettingFileDialog = new SaveFileDialog
                {
                    Title = "ピース配置を保存",
                    DefaultExt = "txt",
                    FileName = string.IsNullOrEmpty(PiecePlacementSettingSaveRestoreFilePath) ? "ピース配置.txt" : System.IO.Path.GetFileName(PiecePlacementSettingSaveRestoreFilePath),
                    Filter = "テキストファイル (*.txt)|*.txt",
                    InitialDirectory = string.IsNullOrEmpty(PiecePlacementSettingSaveRestoreFilePath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : System.IO.Path.GetDirectoryName(PiecePlacementSettingSaveRestoreFilePath)
                };

                List<string> cellValueList = new List<string>();
                foreach (var item in PiecePlacementSettingDataGrid.Items)
                {
                    if (item is DataRowView row)
                    {
                        for (int index = 0; index < SettingRowColIndex; index++)
                        {
                            cellValueList.Add(row[index].ToString());
                        }
                    }
                }

                if (savePiecePlacementSettingFileDialog.ShowDialog(this) == true)
                {
                    PiecePlacementSettingSaveRestoreFilePath = savePiecePlacementSettingFileDialog.FileName;

                    string piecePlacementSettingText = $@"PieceCount：{PiecePlacementPieceCountComboBox.Text}
Numbers：{string.Join(",", cellValueList)}";

                    File.WriteAllText(savePiecePlacementSettingFileDialog.FileName, piecePlacementSettingText, Encoding.UTF8);

                    msgBox.Title = "ピース配置保存完了";
                    msgBox.MessageBoxSetting(
                        "ピース配置を保存しました。",
                        0,
                        Const.ButtonTextListOkOnly,
                        1,
                        1);
                    msgBox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                msgBox.MessageBoxSetting(
                    ex.Message,
                    1,
                    Const.ButtonTextListOkOnly,
                    1,
                    2);
                msgBox.ShowDialog();
            }
        }

        /// <summary>
        /// ピース配置を読み込みボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void PiecePlacementReadButton_Click(object sender, RoutedEventArgs e)
        {
            var openPiecePlacementSettingFileDialog = new OpenFileDialog
            {
                Title = "ピース配置を開く",
                DefaultExt = "txt",
                FileName = string.IsNullOrEmpty(PiecePlacementSettingReadRestoreFilePath) ? "ピース配置.txt" : System.IO.Path.GetFileName(PiecePlacementSettingReadRestoreFilePath),
                Filter = "テキストファイル (*.txt)|*.txt",
                InitialDirectory = string.IsNullOrEmpty(PiecePlacementSettingReadRestoreFilePath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : System.IO.Path.GetDirectoryName(PiecePlacementSettingReadRestoreFilePath)
            };
            if (openPiecePlacementSettingFileDialog.ShowDialog(this) != true)
            {
                return;
            }

            CustomMessageBox msgBox = new CustomMessageBox() { Owner = this };
            PiecePlacementSettingReadRestoreFilePath = openPiecePlacementSettingFileDialog.FileName;
            string[] settingDataAr;

            try
            {
                // テキストファイルを読み込む。
                string settingText = File.ReadAllText(openPiecePlacementSettingFileDialog.FileName, Encoding.UTF8);
                if (string.IsNullOrWhiteSpace(settingText))
                {
                    msgBox.MessageBoxSetting(
                        "ピース配置を読み込めませんでした。",
                        1,
                        Const.ButtonTextListOkOnly,
                        1,
                        2);
                    msgBox.ShowDialog();
                    return;
                }
                else
                {
                    settingDataAr = settingText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch
            {
                msgBox.MessageBoxSetting(
                    "ピースを読み込めませんでした。",
                    1,
                    Const.ButtonTextListOkOnly,
                    1,
                    2);
                msgBox.ShowDialog();
                return;
            }

            try
            {
                // ピース数・番号共にエラーが無い場合のみ、値を設定する。

                int rowColCount = 0,
                    pieceCountComboBoxSelectedIndex = 0;

                // ピースカウント
                string targetValue = GetSettingValue(settingDataAr, "PieceCount：");
                if (!string.IsNullOrEmpty(targetValue))
                {
                    switch (targetValue)
                    {
                        case "３×３":
                            rowColCount = 3;
                            break;
                        case "４×４":
                            rowColCount = 4;
                            pieceCountComboBoxSelectedIndex = 1;
                            break;
                        case "５×５":
                            rowColCount = 5;
                            pieceCountComboBoxSelectedIndex = 2;
                            break;
                        case "６×６":
                            rowColCount = 6;
                            pieceCountComboBoxSelectedIndex = 3;
                            break;
                        case "７×７":
                            rowColCount = 7;
                            pieceCountComboBoxSelectedIndex = 4;
                            break;
                        case "８×８":
                            rowColCount = 8;
                            pieceCountComboBoxSelectedIndex = 5;
                            break;
                    }
                }

                // 行列数を判定する。
                if (rowColCount == 0)
                {
                    msgBox.MessageBoxSetting(
                        "ピース数が不正です。",
                        1,
                        Const.ButtonTextListOkOnly,
                        1,
                        2);
                    msgBox.ShowDialog();
                    return;
                }

                // 番号
                ReadNumberList.Clear();
                targetValue = GetSettingValue(settingDataAr, "Numbers：");
                if (!string.IsNullOrEmpty(targetValue))
                {
                    // 番号を読み込む。
                    ReadNumberList = targetValue.Split(new string[] { "," }, StringSplitOptions.None).ToList();

                    int lastNumber = rowColCount * rowColCount;

                    // 要素数を判定する。
                    if (lastNumber != ReadNumberList.Count)
                    {
                        msgBox.MessageBoxSetting(
                            string.Concat("ピース数と入力されている番号の個数が一致しません。", Environment.NewLine, "正しい個数：", ConvertNumberWide(lastNumber), Environment.NewLine, "読み込まれた個数：", ConvertNumberWide(ReadNumberList.Count)),
                            1,
                            Const.ButtonTextListOkOnly,
                            1,
                            2);
                        msgBox.ShowDialog();
                        ReadNumberList.Clear();
                        return;
                    }

                    // 最終要素値を判定する。
                    if (lastNumber.ToString() != ReadNumberList.Last())
                    {
                        msgBox.MessageBoxSetting(
                            string.Concat("最終番号が一致しません。", Environment.NewLine, "正しい値：", lastNumber, Environment.NewLine, "読み込まれた値：", ReadNumberList.Last()),
                            1,
                            Const.ButtonTextListOkOnly,
                            1,
                            2);
                        msgBox.ShowDialog();
                        ReadNumberList.Clear();
                        return;
                    }
                }
                else
                {
                    msgBox.MessageBoxSetting(
                        "番号が入力されていません。",
                        1,
                        Const.ButtonTextListOkOnly,
                        1,
                        2);
                    msgBox.ShowDialog();
                    return;
                }

                // ピース数コンボボックスの選択位置と読み込んだピース数コンボボックスの選択位置を判定する。
                if (PiecePlacementPieceCountComboBox.SelectedIndex == pieceCountComboBoxSelectedIndex)
                {
                    // 一致している場合、ピース数コンボボックス選択後処理を呼び出す。
                    PiecePlacementPieceCountComboBox_SelectionChanged(null, null);
                }
                else
                {
                    // 不一致の場合、ピース数コンボボックスの選択位置を設定する。
                    // （設定後、自動でピース数コンボボックス選択後処理を呼び出される。）
                    PiecePlacementPieceCountComboBox.SelectedIndex = pieceCountComboBoxSelectedIndex;
                }

                msgBox.Title = "ピース配置読み込み完了";
                msgBox.MessageBoxSetting(
                    "ピース配置を読み込みました。",
                    0,
                    Const.ButtonTextListOkOnly,
                    1,
                    1);
                msgBox.ShowDialog();
            }
            catch (Exception ex)
            {
                msgBox.MessageBoxSetting(
                    ex.Message,
                    1,
                    Const.ButtonTextListOkOnly,
                    1,
                    2);
                msgBox.ShowDialog();
            }
        }

        /// <summary>
        /// 操作履歴・初期配置を保存ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void OperationHistoryInitSaveButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox msgBox = new CustomMessageBox() { Owner = this };

            try
            {
                var saveOperationHistoryInitFileDialog = new SaveFileDialog
                {
                    Title = "操作履歴・初期配置を保存",
                    DefaultExt = "txt",
                    FileName = string.IsNullOrEmpty(OperationHistoryInitSaveRestoreFilePath) ? "操作履歴・初期配置.txt" : System.IO.Path.GetFileName(OperationHistoryInitSaveRestoreFilePath),
                    Filter = "テキストファイル (*.txt)|*.txt",
                    InitialDirectory = string.IsNullOrEmpty(OperationHistoryInitSaveRestoreFilePath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : System.IO.Path.GetDirectoryName(OperationHistoryInitSaveRestoreFilePath)
                };
                if (saveOperationHistoryInitFileDialog.ShowDialog(this) == true)
                {
                    OperationHistoryInitSaveRestoreFilePath = saveOperationHistoryInitFileDialog.FileName;

                    List<string> cellValueList = new List<string>();
                    foreach (var item in InitDataGrid.Items)
                    {
                        if (item is DataRowView row)
                        {
                            for (int index = 0; index < InitRowColIndex; index++)
                            {
                                cellValueList.Add(row[index].ToString());
                            }
                        }
                    }

                    string operationHistoryText = $@"◆操作履歴
{OperationHistoryTextBox.Text}
PieceCount：{PieceCountText}
Numbers：{string.Join(",", cellValueList)}";

                    File.WriteAllText(saveOperationHistoryInitFileDialog.FileName, operationHistoryText, Encoding.UTF8);

                    msgBox.Title = "操作履歴・初期配置保存完了";
                    msgBox.MessageBoxSetting(
                        "操作履歴・初期配置を保存しました。",
                        0,
                        Const.ButtonTextListOkOnly,
                        1,
                        1);
                    msgBox.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                msgBox.MessageBoxSetting(
                    ex.Message,
                    1,
                    Const.ButtonTextListOkOnly,
                    1,
                    2);
                msgBox.ShowDialog();
            }
        }

        /// <summary>
        /// 操作履歴編集チェックボックス・チェック後処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void OperationHistoryEditCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            OperationHistoryTextBox.IsReadOnly = false;
            OperationHistoryTextBox.Background = Brushes.Azure;
        }

        /// <summary>
        /// 操作履歴編集チェックボックス・非チェック後処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void OperationHistoryEditCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            OperationHistoryTextBox.IsReadOnly = true;
            OperationHistoryTextBox.Background = Brushes.Silver;
        }

        /// <summary>
        /// スライドパズルに反映ボタン（操作履歴）押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void InitSlidePuzzleReflectionButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox msgBox = new CustomMessageBox()
            {
                Owner = this,
                Title = "初期配置反映確認"
            };
            msgBox.MessageBoxSetting(
                "初期配置をスライドパズルに反映しますか？",
                3,
                Const.ButtonTextListForQustion,
                2,
                1);
            msgBox.ShowDialog();
            if (msgBox.MessageBoxResult == CustomMessageBox.RETURN_BUTTON1)
            {
                List<int> numberList = new List<int>();
                foreach (var item in InitDataGrid.Items)
                {
                    if (item is DataRowView row)
                    {
                        for (int index = 0; index < InitRowColIndex; index++)
                        {
                            numberList.Add(int.Parse(row[index].ToString()));
                        }
                    }
                }

                // ピースリスト設定処理を呼び出す。
                SetPieceList(InitRowColIndex, numberList);

                msgBox = new CustomMessageBox()
                {
                    Owner = this,
                    Title = "初期位置反映完了"
                };
                msgBox.MessageBoxSetting(
                    "初期配置をスライドパズルに反映しました。",
                    0,
                    Const.ButtonTextListOkOnly,
                    1,
                    1);
                msgBox.ShowDialog();
            }
        }

        /// <summary>
        /// ピース配置に反映ボタン押下処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void PiecePlacementReflectionButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox msgBox = new CustomMessageBox()
            {
                Owner = this,
                Title = "初期配置反映確認"
            };
            msgBox.MessageBoxSetting(
                "初期配置をピース配置に反映しますか？",
                3,
                Const.ButtonTextListForQustion,
                2,
                1);
            msgBox.ShowDialog();
            if (msgBox.MessageBoxResult == CustomMessageBox.RETURN_BUTTON1)
            {
                // エラーメッセージを非表示にし、アニメーションを停止する。
                PiecePlacementSettingErrorTextBlock.Visibility = Visibility.Hidden;
                PiecePlacementSettingErrorTextBlockStoryboard?.Stop();

                // ピース数コンボボックス選択後処理を呼び出すため、
                // 一旦ピース数コンボボックスの選択項目を未選択にする。
                PiecePlacementPieceCountComboBox.SelectedIndex = -1;

                // 初期行列数を判定する。
                if (InitRowColIndex == 3)
                {
                    PiecePlacementPieceCountComboBox.SelectedIndex = 0;
                }
                else if (InitRowColIndex == 4)
                {
                    PiecePlacementPieceCountComboBox.SelectedIndex = 1;
                }
                else if (InitRowColIndex == 5)
                {
                    PiecePlacementPieceCountComboBox.SelectedIndex = 2;
                }
                else if (InitRowColIndex == 6)
                {
                    PiecePlacementPieceCountComboBox.SelectedIndex = 3;
                }
                else if (InitRowColIndex == 7)
                {
                    PiecePlacementPieceCountComboBox.SelectedIndex = 4;
                }
                else
                {
                    PiecePlacementPieceCountComboBox.SelectedIndex = 5;
                }

                // データを設定する。
                DataView copyView = InitDataGrid.ItemsSource as DataView;
                PiecePlacementSettingDataGrid.ItemsSource = copyView.Table.Copy().DefaultView;

                // ピース配置データグリッドセル値データテーブルを設定する。
                PiecePlacementSettingDataGridCellValueDataTable = copyView.Table.Copy();

                // 選択タブを、【ピース配置設定】にする。
                SettingTabControl.SelectedIndex = 1;

                msgBox = new CustomMessageBox()
                {
                    Owner = this,
                    Title = "初期位置反映完了"
                };
                msgBox.MessageBoxSetting(
                    "初期配置をピース配置に反映しました。",
                    0,
                    Const.ButtonTextListOkOnly,
                    1,
                    1);
                msgBox.ShowDialog();
            }
        }

        #endregion

        #region ヘルパーメソッド

        /// <summary>
        /// 完成率設定処理
        /// </summary>
        private void SetCompletionRate()
        {
            // 完成率を算出し、設定する。
            int lastNumber = RowColIndex * RowColIndex, matchCount = 0;
            string tempNumber;
            List<int> numberList = new List<int>();

            // ピーステーブルをリスト化する。
            foreach (DataRow row in PieceTable.Rows)
            {
                foreach (var number in row.ItemArray)
                {
                    tempNumber = number.ToString();
                    if (string.IsNullOrEmpty(tempNumber))
                    {
                        numberList.Add(lastNumber);
                    }
                    else
                    {
                        numberList.Add(int.Parse(number.ToString()));
                    }
                }
            }

            // 一致数を取得・保持する。
            matchCount = numberList.Where((number, index) => number == index + 1).Count();

            // 完成率を、小数点型として保持する。
            double completionRate = double.Parse(matchCount.ToString()) / double.Parse(lastNumber.ToString()) * 100;

            // 完成率を設定する。
            CompletionRateTextBlock.Text = $@"完成率：{ConvertNumberWide((int)Math.Round(completionRate, 0))}％";
        }

        /// <summary>
        /// ピースリスト設定処理
        /// </summary>
        /// <param name="rowColCount">行列数</param>
        /// <param name="numberList">番号リスト（最終番号は、常に最終項目にする。）</param>
        private void SetPieceList(
            int rowColCount,
            List<int> numberList)
        {
            // 時間更新タイマーを停止させる。
            TimeUpdateTimer.Stop();

            // 完成率ストーリーボードを停止させる。
            CompletionRateStoryboard.Stop();

            // 各メディアプレイヤーを停止する。
            PieceMoveSoundPlayer?.Stop();
            ClearSoundPlayer?.Stop();

            // クリアイメージを取得し、存在する場合、削除する。
            if (LogicalTreeHelper.FindLogicalNode(this, "ClearImage") is Image clearImage)
            {
                PuzzleCanvas.Children.Remove(clearImage);
            }

            // ピース数テキストを設定する。
            PieceCountText = PieceCountComboBox.Text;

            // ピース移動速度を保持する。
            PieceMoveSpeed = ConvertNumberHalf(PieceSpeedComboBox.Text) * 100;

            // ピース移動音パス・クリア音パスを保持する。
            PieceMoveSoundPath = PieceMoveSoundPathTextBox.Text;
            ClearSoundPath = ClearSoundPathTextBox.Text;

            // 秒・タイムをクリアする。
            Seconds = 0;
            TimeTextBlock.Text = "０秒";

            // 操作履歴テキストボックスをクリアする。
            OperationHistoryTextBox.Text = string.Empty;

            // 各フラグを初期化する。
            ClearFlg = false;
            MoveFlg = false;
            CompletionRateAnimationFlg = false;

            // 操作履歴番号を初期化する。
            OperationHistoryNo = 1;

            // 操作履歴情報リストを初期化する。
            OperationHistoryInfoList = new List<OperationHistoryInfo>();

            // ピースリストの項目の有無を判定する。
            if (PieceList.Any())
            {
                // 項目が存在する場合、削除する。
                PieceList.ForEach(piece => PuzzleCanvas.Children.Remove(piece));
            }

            BitmapImage originalImage;
            BitmapImageReadFlg = true;

            // 画像パスを判定する。
            if (string.IsNullOrWhiteSpace(ImagePathTextBox.Text) || !File.Exists(ImagePathTextBox.Text))
            {
                // 存在しない場合

                // 埋め込みリソースの画像を読み込む。
                SystemDrawing.Bitmap bitmap = Properties.Resources.Fox;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, SystemDrawing.Imaging.ImageFormat.Png);
                    memoryStream.Position = 0;
                    originalImage = new BitmapImage();
                    originalImage.BeginInit();
                    originalImage.StreamSource = memoryStream;
                    originalImage.CacheOption = BitmapCacheOption.OnLoad;
                    originalImage.EndInit();
                }

                // パズル画像テキストボックスに入力済み、かつファイルが存在しない場合、エラーメッセージを表示する。
                if (!string.IsNullOrWhiteSpace(ImagePathTextBox.Text) && !File.Exists(ImagePathTextBox.Text))
                {
                    BitmapImageReadFlg = false;
                }
            }
            else
            {
                // 存在する場合

                // 入力された画像パスの画像を読み込む。
                try
                {
                    // 入力された画像パスの画像を読み込む。
                    originalImage = new BitmapImage(new Uri(ImagePathTextBox.Text, UriKind.RelativeOrAbsolute));
                }
                catch
                {
                    // 埋め込みリソースの画像を読み込む。
                    SystemDrawing.Bitmap bitmap = Properties.Resources.Fox;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        bitmap.Save(memoryStream, SystemDrawing.Imaging.ImageFormat.Png);
                        memoryStream.Position = 0;
                        originalImage = new BitmapImage();
                        originalImage.BeginInit();
                        originalImage.StreamSource = memoryStream;
                        originalImage.CacheOption = BitmapCacheOption.OnLoad;
                        originalImage.EndInit();
                    }

                    BitmapImageReadFlg = false;
                }
            }

            // ピースサイズを設定する。
            PieceSize = 100;
            if (PieceSizeComboBox.SelectedIndex == 0)
            {
                PieceSize = 50;
            }
            else if (PieceSizeComboBox.SelectedIndex == 1)
            {
                PieceSize = 60;
            }
            else if (PieceSizeComboBox.SelectedIndex == 2)
            {
                PieceSize = 70;
            }
            else if (PieceSizeComboBox.SelectedIndex == 3)
            {
                PieceSize = 80;
            }
            else if (PieceSizeComboBox.SelectedIndex == 4)
            {
                PieceSize = 90;
            }

            // パズルイメージのサイズを設定する。
            PuzzleImage.Width = PieceSize * rowColCount;
            PuzzleImage.Height = PuzzleImage.Width;

            // ピース数を保持する。
            int pieceCount = rowColCount * rowColCount;

            // スケールを保持する。
            double scale = rowColCount * PieceSize;

            int index;

            // ピース数コンボボックスの項目を設定する。
            PieceNumberComboBox.Items.Clear();
            for (index = 1; index < pieceCount; index++)
            {
                PieceNumberComboBox.Items.Add(ConvertNumberWide(index));
            }
            PieceNumberComboBox.SelectedIndex = 0;

            // 画像をリサイズする。
            TransformedBitmap resizedImage = new TransformedBitmap(originalImage, new ScaleTransform(scale / originalImage.PixelWidth, scale / originalImage.PixelHeight));
            RenderOptions.SetBitmapScalingMode(resizedImage, BitmapScalingMode.HighQuality);

            // パズル画像を設定する。
            DropShadowEffect puzzleImageGlowEffect = new DropShadowEffect
            {
                Color = Colors.Blue,
                // ぼかし半径
                BlurRadius = 30,
                // 影の深さを0にして光彩する。
                ShadowDepth = 0,
                // 光彩の不透明度
                Opacity = 1
            };
            PuzzleImage.Source = resizedImage;
            PuzzleImage.Effect = puzzleImageGlowEffect;

            // 背景を取得し、存在する場合、削除する。
            if (LogicalTreeHelper.FindLogicalNode(this, "BackgroundRectangle") is Rectangle BackgroundRectangle)
            {
                PuzzleCanvas.Children.Remove(BackgroundRectangle);
            }

            // 背景を設定する。
            BackgroundRectangle = new Rectangle
            {
                Name = "BackgroundRectangle",
                Width = PuzzleImage.Width,
                Height = PuzzleImage.Height,
                Fill = BackgroundSampleTextBlock.Foreground
            };

            DropShadowEffect BackgroundGlowEffect = new DropShadowEffect
            {
                Color = Colors.DarkViolet,
                // ぼかし半径
                BlurRadius = 30,
                // 影の深さを0にして光彩する。
                ShadowDepth = 0,
                // 光彩の不透明度
                Opacity = 1
            };
            BackgroundRectangle.Effect = BackgroundGlowEffect;

            // 背景を配置する。
            Canvas.SetLeft(BackgroundRectangle, Const.MARGIN_LEFT);
            Canvas.SetTop(BackgroundRectangle, Const.MARGIN_TOP);
            PuzzleCanvas.Children.Add(BackgroundRectangle);

            PieceList = new List<Image>();

            int croppedX = 0,
                croppedY = 0,
                number = 1,
                width = 0,
                height = 0;

            // ピースリストを設定する。
            // 行数ループ
            for (int rowIndex = 0; rowIndex < rowColCount; rowIndex++)
            {
                croppedX = 0;

                // 列数ループ
                for (int colIndex = 0; colIndex < rowColCount; colIndex++)
                {
                    // ピース数と番号が一致する場合、処理を終了する。
                    if (pieceCount == number)
                    {
                        break;
                    }

                    // 画像をリトリミングする。
                    CroppedBitmap croppedImage = new CroppedBitmap(resizedImage, new Int32Rect(croppedX, croppedY, PieceSize, PieceSize));
                    croppedX += PieceSize;

                    // 描画用ビットマップを作成する。
                    width = croppedImage.PixelWidth;
                    height = croppedImage.PixelHeight;
                    RenderTargetBitmap renderBitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);

                    // 描画用のビジュアルを作成する。
                    DrawingVisual drawingVisual = new DrawingVisual();
                    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                    {
                        // 画像を描画する。
                        drawingContext.DrawImage(croppedImage, new Rect(0, 0, width, height));

                        // 枠を描画する。
                        drawingContext.DrawRectangle(null, new Pen(LineColorSampleTextBlock.Foreground, 2), new Rect(0, 0, width, height));

                        // 番号表示チェックボックスのチェックを判定する。
                        if (NumberShowCheckBox.IsChecked == true)
                        {
                            // 番号を描画する。
                            FormattedText formattedText = new FormattedText(
                                ConvertNumberWide(number),
                                CultureInfo.InvariantCulture,
                                FlowDirection.LeftToRight,
                                new Typeface("Yu Gothic UI"),
                                ConvertNumberHalf(FontSizeComboBox.Text),
                                FontColorSampleTextBlock.Foreground,
                                VisualTreeHelper.GetDpi(this).PixelsPerDip);
                            drawingContext.DrawText(formattedText, new Point(5, 5));
                        }
                    }
                    renderBitmap.Render(drawingVisual);

                    // Imageを生成する。
                    Image image = new Image
                    {
                        Name = string.Concat("Image", number.ToString()),
                        Source = renderBitmap,
                        Width = width,
                        Height = height,
                        Tag = number,
                        Cursor = Cursors.Hand,
                    };

                    // 番号をインクリメントする。
                    number++;

                    // マウス左ボタンクリックイベントを設定する。
                    image.MouseLeftButtonDown += new MouseButtonEventHandler(PieceImage_MouseLeftButtonDown);

                    // 光彩効果を生成する。
                    DropShadowEffect glowEffect = new DropShadowEffect
                    {
                        Color = Colors.Blue,
                        // ぼかし半径
                        BlurRadius = 20,
                        // 影の深さを0にして光彩する。
                        ShadowDepth = 0,
                        // 光彩の不透明度
                        Opacity = 0.8
                    };

                    // Imageに光彩効果を設定する。
                    image.Effect = glowEffect;

                    // 描画する画質を設定する。
                    RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);

                    // ピースをピースリストに保持する。
                    PieceList.Add(image);
                }

                croppedY += PieceSize;
            }

            // ピーステーブルを初期化する。
            PieceTable = new DataTable();

            // 初期行列数を設定する。
            InitRowColIndex = rowColCount;

            // 列追加
            for (index = 0; index < rowColCount; index++)
            {
                PieceTable.Columns.Add(index.ToString(), typeof(string));
            }

            // 行追加
            for (index = 0; index < rowColCount; index++)
            {
                PieceTable.Rows.Add();
            }

            int setLeft = Const.MARGIN_LEFT,
                setTop = Const.MARGIN_TOP,
                setCount = 0,
                setRowIndex = 0;

            // ピースを配置する。
            numberList.ForEach(targetNumber =>
            {
                Image targetImage = PieceList.FirstOrDefault(piece => int.Parse(piece.Tag.ToString()) == targetNumber);
                if (targetImage != null)
                {
                    // ピース数と対象番号を判定する。
                    if (pieceCount != targetNumber)
                    {
                        // 最終番号以外の場合

                        // 行列数と設定数を判定する。
                        if (rowColCount == setCount)
                        {
                            // 一致した場合、設定する位置を設定する。
                            setLeft = Const.MARGIN_LEFT;
                            setTop += PieceSize;
                            setCount = 0;
                            setRowIndex++;
                        }

                        // Canvasに描画する。
                        Canvas.SetLeft(targetImage, setLeft);
                        Canvas.SetTop(targetImage, setTop);
                        PuzzleCanvas.Children.Add(targetImage);

                        PieceTable.Rows[setRowIndex][setCount] = targetNumber.ToString();

                        setLeft += PieceSize;
                        setCount++;
                    }
                }
            });

            // 完成率設定処理を呼び出す。
            SetCompletionRate();

            // 初期位置データグリッドを設定する。
            DataTable InitDataTable = new DataTable();

            // 列を追加する。
            for (index = 0; index < InitDataGrid.Columns.Count; index++)
            {
                // 列を追加する。
                InitDataTable.Columns.Add(string.Concat("Column", index.ToString()), typeof(string));
            }

            // データを設定する。
            index = 0;
            for (int rowIndex = 0; rowIndex < rowColCount; rowIndex++)
            {
                InitDataTable.Rows.Add();
                for (int colIndex = 0; colIndex < rowColCount; colIndex++)
                {
                    InitDataTable.Rows[rowIndex][colIndex] = numberList[index];
                    index++;
                }
            }

            // データソースを設定する。
            InitDataGrid.ItemsSource = InitDataTable.DefaultView;

            // 列サイズ・表示設定を行う。
            for (int colIndex = 0; colIndex < InitDataGrid.Columns.Count; colIndex++)
            {
                InitDataGrid.Columns[colIndex].Width = 100;

                if (rowColCount > colIndex)
                {
                    InitDataGrid.Columns[colIndex].Visibility = Visibility.Visible;
                }
                else
                {
                    InitDataGrid.Columns[colIndex].Visibility = Visibility.Collapsed;
                }
            }

            // スクロール位置を初期位置にする。
            InitDataGrid.ScrollIntoView(InitDataGrid.Items[0], InitDataGrid.Columns[0]);

            // タイマーを設定する。
            TimeUpdateTimer = new DispatcherTimer(DispatcherPriority.Normal)
            {
                Interval = TimeSpan.FromSeconds(1),
            };
            TimeUpdateTimer.Tick += TimeUpdateTimer_Tick;

            // ビットマップイメージ読み込みフラグを判定する。
            if (!BitmapImageReadFlg)
            {
                CustomMessageBox msgBox = new CustomMessageBox() { Owner = this };
                msgBox.MessageBoxSetting(
                    "パズル画像が読み込めませんでした。",
                    1,
                    Const.ButtonTextListOkOnly,
                    1,
                    2);
                msgBox.ShowDialog();
            }
        }

        /// <summary>
        /// 定理判定処理
        /// </summary>
        /// <param name="rowColIndex">行列数</param>
        /// <param name="numberList">番号リスト</param>
        /// <returns>結果（true：クリア可能配置・false：クリア不可配置）</returns>
        private bool TheoremJudgment(int rowColIndex, List<int> numberList)
        {
            // 各定理の値を取得し、比較する。
            int theorem1Result = TheoremCheck1(numberList);
            bool theorem1Flg = 0 == theorem1Result % 2;

            int theorem2Result = TheoremCheck2(rowColIndex, numberList);
            bool theorem2Flg = 0 == theorem2Result % 2;

            return (theorem1Flg && theorem2Flg) || (!theorem1Flg && !theorem2Flg);
        }

        /// <summary>
        /// 定理１
        /// </summary>
        /// <param name="numberList">番号リスト</param>
        /// <returns>結果</returns>
        /// <remarks>初期配置から完成形にするまでに、何回パネルを交換すれば良いか？
        /// （番号リストの内容を実際に入れ替えて、完成形にする回数をカウントする。）</remarks>
        private int TheoremCheck1(List<int> numberList)
        {
            List<int> tempList = numberList.ToList();

            int changeCount = 0;
            for (int index = 0; index < tempList.Count; index++)
            {
                // 番号リストの番号と正しい番号を判定する。
                while (tempList[index] != index + 1)
                {
                    // 不一致の場合、番号を入れ替える。
                    (tempList[index], tempList[tempList[index] - 1]) = (tempList[tempList[index] - 1], tempList[index]);
                    changeCount++;
                }
            }

            return changeCount;
        }

        /// <summary>
        /// 定理２
        /// </summary>
        /// <param name="rowColIndex">行列数</param>
        /// <param name="numberList">番号リスト</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// 初期配置の空きと、完成形の空きが何マス離れているか？
        /// （初期配置の空きは固定なので、０のみ返却される。なので、このチェックは不要だが、一応実装しておく。）
        /// </remarks>
        private int TheoremCheck2(int rowColIndex, List<int> numberList)
        {
            DataTable dt = new DataTable();

            int lastNumber = rowColIndex * rowColIndex;

            // 最終番号を０に変更する。
            List<int> copyList = numberList.Select(item =>
            {
                if (lastNumber == item)
                {
                    return 0;
                }
                else
                {
                    return item;
                }
            }).ToList();

            // 列を追加する。
            for (int colIndex = 0; colIndex < rowColIndex; colIndex++)
            {
                dt.Columns.Add(colIndex.ToString(), typeof(int));
            }

            // 行を追加する。
            for (int rowIndex = 0; rowIndex < rowColIndex; rowIndex++)
            {
                DataRow row = dt.NewRow();

                // 値を設定する。
                for (int valueIndex = 0; valueIndex < rowColIndex; valueIndex++)
                {
                    row[valueIndex] = copyList[rowIndex * 3 + valueIndex];
                }
                dt.Rows.Add(row);
            }

            // ランダムに生成された空き位置を取得・保持する。
            int tempRowIndex = 0, tempColIndex = 0;

            // 行ループ
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                // 列ループ
                for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                {
                    if (Equals(0, (int)dt.Rows[rowIndex].ItemArray[colIndex]))
                    {
                        tempRowIndex = rowIndex;
                        tempColIndex = colIndex;
                        break;
                    }
                }
            }

            // 完成形の空きの行位置－ランダムに生成された空きの行位置：①
            // 完成形の空きの列位置－ランダムに生成された空きの列位置：②
            // ①＋②＝完成形の空き位置
            return (rowColIndex - 1 - tempRowIndex) + (rowColIndex - 1 - tempColIndex);
        }

        /// <summary>
        /// ピーステーブルチェック処理
        /// </summary>
        /// <returns>結果（true：順列・false：順列以外）</returns>
        private bool PieceTableCheck()
        {
            int checkValue = 1;
            string targetValue;

            // ピーステーブルに設定されている値を判定する。
            foreach (DataRow row in PieceTable.Rows)
            {
                foreach (var number in row.ItemArray)
                {
                    targetValue = number.ToString();

                    if (!string.IsNullOrEmpty(targetValue) && int.Parse(targetValue) != checkValue)
                    {
                        return false;
                    }
                    checkValue++;
                }
            }

            return true;
        }

        /// <summary>
        /// 操作履歴出力処理
        /// </summary>
        /// <param name="redoFlg">元に戻すフラグ（true：元に戻す・false：元に戻す以外）</param>
        /// <param name="pieceNumber">ピース番号</param>
        /// <param name="directionValue">移動値（0：上・1：下・2：左・3：右）</param>
        private void OutputOperationHistory(bool redoFlg, int pieceNumber, int directionValue)
        {
            if (!string.IsNullOrEmpty(OperationHistoryTextBox.Text))
            {
                OperationHistoryTextBox.Text += Environment.NewLine;
            }

            string setOperationHistory = string.Concat(
                ConvertNumberWide(OperationHistoryNo),
                "回目：",
                ConvertNumberWide(pieceNumber),
                "：");

            if (directionValue == 0)
            {
                setOperationHistory += "↑";
            }
            else if (directionValue == 1)
            {
                setOperationHistory += "↓";
            }
            else if (directionValue == 2)
            {
                setOperationHistory += "←";
            }
            else
            {
                setOperationHistory += "→";
            }

            if (redoFlg)
            {
                setOperationHistory += "（元に戻す）";
            }

            OperationHistoryTextBox.Text += setOperationHistory;
            OperationHistoryTextBox.ScrollToEnd();

            OperationHistoryNo++;
        }

        /// <summary>
        /// 値範囲チェック
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="minValue">最小値</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>結果（true：範囲内・false：範囲外）</returns>
        private bool ValueRangeCheck(int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        /// 重複チェック
        /// </summary>
        /// <param name="numberList">数値リスト</param>
        /// <returns>結果（true：重複有り・false：重複無し）</returns>
        private bool DuplicationCheck(List<int> numberList)
        {
            List<int> tempList = numberList.GroupBy(number => number)
                                .Where(number => number.Count() > 1)
                                .Select(item => item.Key)
                                .ToList();
            return tempList.Any();
        }

        /// <summary>
        /// 設定値取得処理
        /// </summary>
        /// <param name="settingDataAr">設定データ配列</param>
        /// <param name="prefix">プレフィックス</param>
        /// <returns>取得値（未取得の場合、ブランク）</returns>
        private string GetSettingValue(string[] settingDataAr, string prefix)
        {
            foreach (string settingData in settingDataAr)
            {
                if (settingData.StartsWith(prefix))
                {
                    return settingData.Substring(prefix.Length);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// コンボボックス項目設定処理
        /// </summary>
        /// <param name="targetComboBox">対象コンボボックス</param>
        /// <param name="settingDataAr">設定データ配列</param>
        /// <param name="prefix">プレフィックス</param>
        /// <param name="defaultSelectedIndex">デフォルト選択位置</param>
        private void SetComboBoxItem(
            ComboBox targetComboBox,
            string[] settingDataAr,
            string prefix,
            int defaultSelectedIndex)
        {
            string targetValue = GetSettingValue(settingDataAr, prefix);
            if (string.IsNullOrEmpty(targetValue))
            {
                targetComboBox.SelectedIndex = defaultSelectedIndex;
            }
            else
            {
                targetComboBox.SelectedIndex = defaultSelectedIndex;
                foreach (ComboBoxItem item in targetComboBox.Items)
                {
                    if (Equals(targetValue, item.Content))
                    {
                        targetComboBox.Text = targetValue;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// テキストブロック・色設定処理
        /// </summary>
        /// <param name="targeTextBlock">対象テキストブロック</param>
        /// <param name="settingDataAr">設定データ配列</param>
        /// <param name="prefixR">プレフィックスR</param>
        /// <param name="prefixG">プレフィックスG</param>
        /// <param name="prefixB">プレフィックスB</param>
        /// <param name="prefixA">プレフィックスA</param>
        /// <param name="defaultSolidColorBrush">デフォルトカラーブラシ</param>
        private void SetTextBlockForeground(
            TextBlock targeTextBlock,
            string[] settingDataAr,
            string prefixR,
            string prefixG,
            string prefixB,
            string prefixA,
            SolidColorBrush defaultSolidColorBrush)
        {
            string rValue = GetSettingValue(settingDataAr, prefixR),
                gValue = GetSettingValue(settingDataAr, prefixG),
                bValue = GetSettingValue(settingDataAr, prefixB),
                aValue = GetSettingValue(settingDataAr, prefixA);

            if (!string.IsNullOrEmpty(rValue) &&
                !string.IsNullOrEmpty(gValue) &&
                !string.IsNullOrEmpty(bValue) &&
                !string.IsNullOrEmpty(aValue))
            {
                if (byte.TryParse(rValue, out byte r) &&
                    byte.TryParse(gValue, out byte g) &&
                    byte.TryParse(bValue, out byte b) &&
                    byte.TryParse(aValue, out byte a))
                {
                    targeTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(a, r, g, b));
                }
                else
                {
                    targeTextBlock.Foreground = defaultSolidColorBrush;
                }
            }
            else
            {
                targeTextBlock.Foreground = defaultSolidColorBrush;
            }
        }

        /// <summary>
        /// 半角数値→全角数値変換処理
        /// </summary>
        /// <param name="halfNumber">半角数値</param>
        /// <returns>変換した全角数値</returns>
        private string ConvertNumberWide(int halfNumber)
        {
            string halfNumberStr = halfNumber.ToString(), convertNumber = string.Empty;
            foreach (char number in halfNumberStr)
            {
                string value = Const.FullWidthNumberList.ElementAtOrDefault(int.Parse(number.ToString()));
                if (!string.IsNullOrEmpty(value))
                {
                    convertNumber = string.Concat(convertNumber, value);
                }
            }

            return convertNumber;
        }

        /// <summary>
        /// 全角数値→半角数値変換処理
        /// </summary>
        /// <param name="wideNumber">全角数値</param>
        /// <returns>変換した半角数値</returns>
        private int ConvertNumberHalf(string wideNumber)
        {
            string convertNumber = string.Empty;
            foreach (char number in wideNumber)
            {
                for (int index = 0; index < Const.FullWidthNumberList.Count; index++)
                {
                    if (string.Equals(number.ToString(), Const.FullWidthNumberList[index]))
                    {
                        convertNumber = string.Concat(convertNumber, index);
                        break;
                    }
                }
            }

            return int.Parse(convertNumber);
        }

        #endregion
    }
}
