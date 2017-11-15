Public Class Main
    Public roopcount As Integer ' ループした回数を表す変数roopcountを整数型で宣言
    Public probability As Double ' ブラックジャックが出た確率を表す変数probabilityを倍精度浮動小数点数型で宣言
    Public batucount As Integer = 0 ' ×ボタンを押していないフォームかどうかの判定に用いる変数batucountを整数型で宣言(0で初期化)
    Dim finishicode As Integer = 0

    Private Sub Me_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If finishicode = 0 Then
            Dim Answer As MsgBoxResult
            If batucount = 0 Then ' 今のフォームが×ボタンが押された事のあるフォームかどうか
                store.Label3.Text = Label6.Text
                store.Label4.Text = Label7.Text
                store.keep() ' keep関数呼び出し
                roopcount += 1 ' インクリメント(必ず2になる)
                store.roop1 = roopcount ' roopcountの値をstoreフォームのroop1に代入
                store.roop() ' roop関数呼び出し
                probability = store.count21 * 100 / store.roop2 ' ブラックジャックの出現確率計算
            End If
            Answer = MsgBox("終了しますか？" & vbCrLf & "今回のブラックジャック出現率(%)" & probability, MsgBoxStyle.YesNo, "確認")

            If Answer = MsgBoxResult.No Then ' メッセージボックスで「いいえ」が押された場合
                e.Cancel = True ' フォーム削除の処理をキャンセルするための処理
                batucount = 1 ' ×ボタンが押された事を表すために、batucountに1を代入
            End If
        End If

    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        roopcount = 1 ' プログラムを終了までに何回プレイしたかを求めるのに必要なroopcountに1を代入(後にStoreフォームのroop関数で用いる)

        Dim ransu As Integer 'ransu=乱数
        Dim goukei1 As Integer  '相手の合計値
        goukei1 = 0 '相手の合計値を初期化
        Dim goukei2 As Integer  '自分の合計値
        goukei2 = 0 '自分の合計値を初期化
        Dim r As New Random '乱数宣言
        Dim number1 As Integer = r.Next(1, 14)  '乱数生成
        ransu = number1.ToString    '乱数を変数ransuに代入

        Label1.Text = ransu     'ラベルに生成した乱数を表示


        printt(1, ransu)    'printt関数を呼び出しpictureboxに表面表示

        If Label1.Text <= 10 Then
            goukei1 = Label1.Text
        Else
            goukei1 = 10
        End If
        Label11.Text = goukei1


        Dim number2 As Integer = r.Next(1, 14)  '乱数生成
        ransu = number2.ToString    '乱数を変数ransuに代入

        Label6.Text = ransu     'ラベルに生成した乱数を表示


        printt(6, ransu)    'printt関数を呼び出しpictureboxに表面表示

        If Label6.Text <= 10 Then
            If Label6.Text = 1 Then
                goukei2 = 11
            End If
            goukei2 = ransu
        Else
            goukei2 = 10
        End If

        Dim number3 As Integer = r.Next(1, 14)  '乱数生成
        ransu = number3.ToString    '乱数を変数ransuに代入

        Label7.Text = ransu     'ラベルに生成した乱数を表示

        printt(7, ransu)    'printt関数を呼び出しpictureboxに表面表示
        If Label7.Text < 10 Then
            If goukei2 = 1 Then '1が含まれているかどうか'
                If 11 + Label7.Text <= 20 Then '1枚目を11として2枚目との合計が20以下の場合(最大値：1枚目が1で2枚目が9なら20)'
                    goukei2 = 11 + Label7.Text '1を11として合計値に足しこみ
                End If
            ElseIf Label7.Text = 1 Then '二枚目が1ならば'
                If goukei2 + 11 <= 21 Then '2枚目を11として1枚目との合計が21以下の場合(最大値：1枚目が10で2枚目が1ならBJ)'
                    goukei2 = goukei2 + 11 '相手二枚目の手札が10未満で1を含むなら1を11として合計値に足しこみ
                End If
            Else
                goukei2 = goukei2 + Label7.Text '1が含まれていない場合はそのままの値を足す'
            End If
        ElseIf goukei2 = 1 Then '相手の二枚目の手札が10以上でブラックジャックが成立している場合'
            goukei2 = 21
        Else
            goukei2 = goukei2 + 10  'そうでなければ合計値に10を加算する
        End If
        Label12.Text = goukei2
    End Sub
    'この関数の上部はディーラーのHITを処理する部分で、下部は勝敗の判断を行う関数'
    Private Sub stand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Stand.Click
        finishicode = 1 'finishicodeに1を代入

        Me.Controls.Remove(PictureBox2)

        Dim ransu As Integer 'ransu=乱数
        Dim goukei1 As Integer  '相手の合計値
        goukei1 = Label11.Text  'ラベル11の値を相手の合計値に代入
        Dim goukei2 As Integer  '自分の合計値
        Dim kaisu1 As Integer   '相手の手札を引いた回数
        kaisu1 = 0  'kaisu1初期化
        Dim r As New Random '乱数宣言
        Dim f1 As New Main  'メインフォーム呼び出しに使用
        Dim answer2 As New MsgBoxResult 'メッセージボックスYesNo型の結果代入変数
        Dim ten_over_judge As Integer '3枚目以降のカードについて、適切な値を設定するために使用する'

        Dim number1 As Integer = r.Next(1, 14)  '乱数生成
        ransu = number1.ToString    '乱数を変数ransuに代入

        Label2.Text = ransu     'ラベルに生成した乱数を表示

        printt(2, ransu)    'printt関数を呼び出しpictureboxに表面表示

        If Label2.Text < 10 Then
            If goukei1 = 1 Then '1が含まれているかどうか'
                If 11 + Label2.Text <= 20 Then '1枚目を11として2枚目との合計が20以下の場合(最大値：1枚目が1で2枚目が9なら20)'
                    goukei1 = 11 + Label2.Text '1を11として合計値に足しこみ
                End If
            ElseIf Label2.Text = 1 Then '二枚目が1ならば'
                If goukei1 + 11 <= 21 Then '2枚目を11として1枚目との合計が21以下の場合(最大値：1枚目が10で2枚目が1ならBJ)'
                    goukei1 = goukei1 + 11 '相手二枚目の手札が10未満で1を含むなら1を11として合計値に足しこみ
                End If
            Else
                goukei1 = goukei1 + Label2.Text '1が含まれていない場合はそのままの値を足す'
            End If
        ElseIf goukei1 = 1 Then '相手の二枚目の手札が10以上でブラックジャックが成立している場合'
            goukei1 = 21
        Else
            goukei1 = goukei1 + 10  'そうでなければ合計値に10を加算する
        End If



        If goukei1 < 17 Then
            Do  'ループ
                Select Case kaisu1 'kaisu1について
                    Case 0  '一回目
                        Dim number2 As Integer = r.Next(1, 14)  '乱数生成
                        ransu = number2.ToString　'乱数を変数ransuに代入

                        Label3.Text = ransu　'ラベルに生成した乱数を表示

                        printt(3, ransu)　'printt関数を呼び出しpictureboxに表面表示

                        If Label3.Text <= 10 Then '10以下の場合'
                            If Label3.Text = 1 And goukei1 + 11 <= 21 Then '3枚目が1の場合であり、かつ、これまでのカードとの合計が21以下の場合'
                                ten_over_judge = 11 '三枚目のカードである1を11とする'
                            Else
                                ten_over_judge = Label3.Text '1を1のままとする'
                            End If
                        Else
                            ten_over_judge = 10 '10より大きい値は10とする'
                        End If
                        goukei1 = goukei1 + ten_over_judge

                        kaisu1 = kaisu1 + 1 '3枚目の時のkaisu1を0として、引く度にその値をインクリメント'
                    Case 1  '二回目
                        Dim number3 As Integer = r.Next(1, 14)  '乱数生成
                        ransu = number3.ToString    '乱数を変数ransuに代入

                        Label4.Text = ransu     'ラベルに生成した乱数を表示

                        printt(4, ransu)    'printt関数を呼び出しpictureboxに表面表示
                        If Label4.Text <= 10 Then
                            If Label4.Text = 1 And goukei1 + 11 <= 21 Then '4枚目が1の場合であり、かつ、これまでのカードとの合計が21以下の場合'
                                ten_over_judge = 11 '三枚目のカードである1を11とする'
                            Else
                                ten_over_judge = Label4.Text '1を1のままとする'
                            End If
                        Else
                            ten_over_judge = 10 '10より大きい値は10とする'
                        End If
                        goukei1 = goukei1 + ten_over_judge 'ディーラーの合計値を更新'

                        kaisu1 = kaisu1 + 1 '4枚目の時のkaisu1を1として、引く度にその値をインクリメント'
                    Case 2  '三回目
                        Dim number4 As Integer = r.Next(1, 14)  '乱数生成
                        ransu = number4.ToString    '乱数を変数ransuに代入

                        Label5.Text = ransu     'ラベルに生成した乱数を表示

                        printt(5, ransu)    'printt関数を呼び出しpictureboxに表面表示
                        If Label5.Text <= 10 Then
                            If Label5.Text = 1 And goukei1 + 11 <= 21 Then '5枚目が1の場合であり、かつ、これまでのカードとの合計が21以下の場合'
                                ten_over_judge = 11 '三枚目のカードである1を11とする'
                            Else
                                ten_over_judge = Label5.Text '1を1のままとする'
                            End If
                        Else
                            ten_over_judge = 10 '10より大きい値は10とする'
                        End If
                        goukei1 = goukei1 + ten_over_judge 'ディーラーの合計値を更新'

                        kaisu1 = kaisu1 + 1 '5枚目の時のkaisu1を2として、引く度にその値をインクリメント'
                End Select
            Loop Until goukei1 >= 17 Or kaisu1 >= 3 '17未満の数字の場合である限り、カードを5枚まで引くことができる。'
            Label11.Text = goukei1  '合計値をラベルに反映
            goukei2 = Label12.Text  '自分の現在の合計値をgoukei2に代入
        End If
        If kaisu1 = 3 And (goukei1 < 17 Or (goukei1 = 17 And (Label1.Text = "1" Or Label2.Text = "1" Or Label3.Text = "1" Or Label4.Text = "1" Or Label5.Text = "1"))) Then 'kaisu1が3(5枚目まで引いている状態)であり、6枚目を引かないといけない場合(まだ17未満場合 or Dealer must hit on soft 17を採用しているので、ソフト17の時だけは17でもHITしないといけないので、5枚目でソフト17になった場合の二つが該当
            Dim Answer As MsgBoxResult
            Answer = MsgBox("これ以上HITできない仕様になっています。" & vbCrLf & " 申し訳ございませんが、このゲームをノーカウントとし、STANDを押して次のゲームに進んでください。", MsgBoxStyle.OkOnly, "error")
            kaisu1 = kaisu1 + 1
        End If
        If goukei1 = 17 And (Label1.Text = "1" Or Label2.Text = "1" Or Label3.Text = "1" Or Label4.Text = "1" Or Label5.Text = "1") Then 'Dealer must hit on soft 17を採用しているので、ソフト17の時だけ17でもHITしないといけないので、この条件式に真であれば、if文内でもう一回だけ引く。'
            If kaisu1 = 0 Then
                Dim number2 As Integer = r.Next(1, 14)  '乱数生成
                ransu = number2.ToString    '乱数を変数ransuに代入

                Label3.Text = ransu     'ラベルに生成した乱数を表示

                printt(3, ransu)    'printt関数を呼び出しpictureboxに表面表示
                If Label3.Text <= 10 Then
                    If Label3.Text = 1 And goukei1 + 11 <= 21 Then '3枚目が1の場合であり、かつ、これまでのカードとの合計が21以下の場合'
                        ten_over_judge = 11 '三枚目のカードである1を11とする'
                    Else
                        ten_over_judge = Label3.Text '1を1のままとする'
                    End If
                Else
                    ten_over_judge = 10 '10より大きい値は10とする'
                End If
                goukei1 = goukei1 + ten_over_judge 'ディーラーの合計値を更新'
            ElseIf kaisu1 = 1 Then
                Dim number3 As Integer = r.Next(1, 14)  '乱数生成
                ransu = number3.ToString    '乱数を変数ransuに代入

                Label4.Text = ransu     'ラベルに生成した乱数を表示

                printt(4, ransu)    'printt関数を呼び出しpictureboxに表面表示
                If Label4.Text <= 10 Then
                    If Label4.Text = 1 And goukei1 + 11 <= 21 Then '4枚目が1の場合であり、かつ、これまでのカードとの合計が21以下の場合'
                        ten_over_judge = 11 '三枚目のカードである1を11とする'
                    Else
                        ten_over_judge = Label4.Text '1を1のままとする'
                    End If
                Else
                    ten_over_judge = 10 '10より大きい値は10とする'
                End If
                goukei1 = goukei1 + ten_over_judge 'ディーラーの合計値を更新'
            ElseIf kaisu1 = 2 Then
                Dim number4 As Integer = r.Next(1, 14)  '乱数生成
                ransu = number4.ToString    '乱数を変数ransuに代入

                Label5.Text = ransu     'ラベルに生成した乱数を表示

                printt(5, ransu)    'printt関数を呼び出しpictureboxに表面表示
                If Label5.Text <= 10 Then
                    If Label5.Text = 1 And goukei1 + 11 <= 21 Then '5枚目が1の場合であり、かつ、これまでのカードとの合計が21以下の場合'
                        ten_over_judge = 11 '三枚目のカードである1を11とする'
                    Else
                        ten_over_judge = Label5.Text '1を1のままとする'
                    End If
                Else
                    ten_over_judge = 10 '10より大きい値は10とする'
                End If
                goukei1 = goukei1 + ten_over_judge 'ディーラーの合計値を更新'
            End If
        End If
        '合計値が17以上になるか、回数が2以上になるまで繰り返す
        Label11.Text = goukei1  '合計値をラベルに反映
        goukei2 = Label12.Text  '自分の現在の合計値をgoukei2に代入



        If goukei1 < 22 Then 'goukei1が22未満の場合
            If goukei1 < goukei2 Then '相手の合計値よりも自分の合計値のほうが多い

                Dim keep As String
                keep = Me.Label12.Text

                Dim Answer As MsgBoxResult ' MsgBoxの結果を保存しておくための変数Answerを宣言
                ' ディーラーの21チェック
                store.Label3.Text = Label1.Text
                store.Label4.Text = Label2.Text
                store.keep() ' storeフォームのkeep関数を呼び出す(21の数を数える関数)
                ' 自分の21チェック
                store.Label3.Text = Label6.Text ' storeフォームのLabel3にLabel6の値を代入
                store.Label4.Text = Label7.Text
                store.keep() ' storeフォームのkeep関数を呼び出す
                Answer = MsgBox("     あなたの勝ちです" & vbCrLf & "     もう一度しますか？", MsgBoxStyle.YesNo, "勝利")
                roopcount += 1 ' インクリメント(必ず2になる)
                store.roop1 = roopcount ' roopcountの値をstoreフォームのroop1に代入
                store.roop() ' storeフォームのroop関数を呼び出す
                If Answer = vbYes Then
                    f1.Show() ' Mainフォームを表示
                    My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理

                    Me.Close() ' 今開いているフォームを閉じる
                Else
                    probability = store.count21 * 100 / store.roop2 ' ブラックジャックの出現確率計算
                    answer2 = MsgBox("本当に閉じますか？" & vbCrLf & "今回のブラックジャック出現率(%)" & probability, MsgBoxStyle.YesNo + vbExclamation, "確認") ' MsgBoxの表示と、結果をanswer2に代入
                    If answer2 = vbYes Then ' Yesの場合
                        Me.Close() ' 今開いているフォームを閉じる
                    Else
                        f1.Show() ' Mainフォームを表示
                        My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
                        Me.Close() ' 今開いているフォームを閉じる
                    End If
                End If
            ElseIf goukei2 = goukei1 Then   '双方の合計が一致していれば
                Dim Answer As MsgBoxResult ' MsgBoxの結果を保存しておくための変数Answerを宣言
                ' ディーラーの21チェック
                store.Label3.Text = Label1.Text
                store.Label4.Text = Label2.Text
                store.keep() ' storeフォームのkeep関数を呼び出す(21の数を数える関数)
                ' 自分の21チェック
                store.Label3.Text = Label6.Text ' storeフォームのLabel3にLabel6の値を代入
                store.Label4.Text = Label7.Text
                store.keep() ' storeフォームのkeep関数を呼び出す
                Answer = MsgBox("     引き分けです" & vbCrLf & "     もう一度しますか？", MsgBoxStyle.YesNo, "引き分け")
                roopcount += 1 ' インクリメント(必ず2になる)
                store.roop1 = roopcount ' roopcountの値をstoreフォームのroop1に代入
                store.roop() ' storeフォームのroop関数を呼び出す
                If Answer = vbYes Then
                    f1.Show() ' Mainフォームを表示
                    My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
                    Me.Close() ' 今開いているフォームを閉じる
                Else
                    probability = store.count21 * 100 / store.roop2 ' ブラックジャックの出現確率計算
                    answer2 = MsgBox("本当に閉じますか？" & vbCrLf & "今回のブラックジャック出現率(%)" & probability, MsgBoxStyle.YesNo + vbExclamation, "確認") ' MsgBoxの表示と、結果をanswer2に代入
                    If answer2 = vbYes Then ' Yesの場合
                        Me.Close() ' 今開いているフォームを閉じる
                    Else
                        f1.Show() ' Mainフォームを表示
                        My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
                        Me.Close() ' 今開いているフォームを閉じる
                    End If
                End If
            Else
                Dim Answer As MsgBoxResult ' MsgBoxの結果を保存しておくための変数Answerを宣言
                ' ディーラーの21チェック
                store.Label3.Text = Label1.Text
                store.Label4.Text = Label2.Text
                store.keep() ' storeフォームのkeep関数を呼び出す(21の数を数える関数)
                ' 自分の21チェック
                store.Label3.Text = Label6.Text ' storeフォームのLabel3にLabel6の値を代入
                store.Label4.Text = Label7.Text
                store.keep() ' storeフォームのkeep関数を呼び出す
                Answer = MsgBox("     あなたの負けです" & vbCrLf & "     もう一度しますか？", MsgBoxStyle.YesNo, "敗北")
                roopcount += 1 ' インクリメント(必ず2になる)
                store.roop1 = roopcount ' roopcountの値をstoreフォームのroop1に代入
                store.roop() ' storeフォームのroop関数を呼び出す
                If Answer = vbYes Then
                    f1.Show() ' Mainフォームを表示
                    My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
                    Me.Close() ' 今開いているフォームを閉じる
                Else
                    probability = store.count21 * 100 / store.roop2 ' ブラックジャックの出現確率計算
                    answer2 = MsgBox("本当に閉じますか？" & vbCrLf & "今回のブラックジャック出現率(%)" & probability, MsgBoxStyle.YesNo + vbExclamation, "確認") ' MsgBoxの表示と、結果をanswer2に代入
                    If answer2 = vbYes Then ' Yesの場合
                        Me.Close() ' 今開いているフォームを閉じる
                    Else
                        f1.Show() ' Mainフォームを表示
                        My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
                        Me.Close() ' 今開いているフォームを閉じる
                    End If
                End If
            End If

        Else
            Dim Answer As MsgBoxResult ' MsgBoxの結果を保存しておくための変数Answerを宣言
            ' ディーラーの21チェック
            store.Label3.Text = Label1.Text
            store.Label4.Text = Label2.Text
            store.keep() ' storeフォームのkeep関数を呼び出す(21の数を数える関数)
            ' 自分の21チェック
            store.Label3.Text = Label6.Text ' storeフォームのLabel3にLabel6の値を代入
            store.Label4.Text = Label7.Text
            store.keep() ' storeフォームのkeep関数を呼び出す
            Answer = MsgBox("     あなたの勝ちです" & vbCrLf & "     もう一度しますか？", MsgBoxStyle.YesNo, "ディーラバスト")
            roopcount += 1 ' インクリメント(必ず2になる)
            store.roop1 = roopcount ' roopcountの値をstoreフォームのroop1に代入
            store.roop() ' storeフォームのroop関数を呼び出す
            If Answer = vbYes Then
                f1.Show() ' Mainフォームを表示
                My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
                Me.Close() ' 今開いているフォームを閉じる
            Else
                probability = store.count21 * 100 / store.roop2 ' ブラックジャックの出現確率計算
                answer2 = MsgBox("本当に閉じますか？" & vbCrLf & "今回のブラックジャック出現率(%)" & probability, MsgBoxStyle.YesNo + vbExclamation, "確認")
                If answer2 = vbYes Then
                    Me.Close() ' 今開いているフォームを閉じる
                Else
                    f1.Show() ' Mainフォームを表示
                    My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
                    Me.Close() ' 今開いているフォームを閉じる
                End If
            End If
        End If

    End Sub

    Private Sub Hit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hit.Click
        Dim ransu As Integer 'ransu=乱数
        Dim goukei2 As Integer  '自分の合計値
        Static kaisu2 As Integer    '自分の引いた回数
        goukei2 = Label12.Text  '現在の合計値を取得
        kaisu2 = Label13.Text   '現在の自分の引いた回数を取得
        Dim r As New Random     '乱数宣言
        Dim f1 As New Main ' Mainフォームのインスタンスを生成
        Dim answer2 As New MsgBoxResult ' MsgBoxの結果を保存しておくための変数answer2を宣言
        Dim ten_over_judge As Integer '3枚目以降のカードについて、適切な値を設定するために使用する'

        Select Case kaisu2  'kaisu2について
            Case 0  '一回目
                Dim number1 As Integer = r.Next(1, 14)  '乱数生成
                ransu = number1.ToString    '乱数を変数ransuに代入

                Label8.Text = ransu     'ラベルに生成した乱数を表示

                printt(8, ransu)    'printt関数を呼び出しpictureboxに表面表示
                If Label6.Text = 1 Or Label7.Text = 1 Then ' これまでのカードに1が含まれている場合(今回引いたカードについての処理は下のIf文で処理)
                    If goukei2 + Label8.Text > 21 Then ' 1があり、かつ、この条件が真ならば、一つでも1を11として扱うと、バーストするので、1はすべて1として扱う(If文内で再計算する)
                        goukei2 = Integer.Parse(Label6.Text) + Integer.Parse(Label7.Text) ' 1を1として合計値を再計算
                    End If
                End If
                If Label8.Text <= 10 Then '10以下の場合'
                    If Label8.Text = 1 And goukei2 + 11 <= 21 Then '3枚目が1の場合であり、かつ、これまでのカードとの合計が21以下の場合'
                        ten_over_judge = 11 '三枚目のカードである1を11とする'
                    Else
                        ten_over_judge = Label8.Text '1を1のままとする'
                    End If
                Else
                    ten_over_judge = 10 '10より大きい値は10とする'
                End If
                goukei2 = goukei2 + ten_over_judge ' 自分の合計値の更新
                kaisu2 = kaisu2 + 1
            Case 1  '二回目
                Dim number2 As Integer = r.Next(1, 14)  '乱数生成
                ransu = number2.ToString    '乱数を変数ransuに代入

                Label9.Text = ransu     'ラベルに生成した乱数を表示

                printt(9, ransu)    'printt関数を呼び出しpictureboxに表面表示
                If Label6.Text = 1 Or Label7.Text = 1 Or Label8.Text = 1 Then ' これまでのカードに1が含まれている場合(今回引いたカードについての処理は下のIf文で処理)
                    If goukei2 + Label9.Text > 21 Then ' 1があり、かつ、この条件が真ならば、一つでも1を11として扱うと、バーストするので、1はすべて1として扱う(If文内で再計算する)
                        goukei2 = Integer.Parse(Label6.Text) + Integer.Parse(Label7.Text) + Integer.Parse(Label8.Text) ' 1を1として合計値を再計算
                    End If
                End If
                If Label9.Text <= 10 Then '10以下の場合'
                    If Label9.Text = 1 And goukei2 + 11 <= 21 Then '3枚目が1の場合であり、かつ、これまでのカードとの合計が21以下の場合'
                        ten_over_judge = 11 '三枚目のカードである1を11とする'
                    Else
                        ten_over_judge = Label9.Text '1を1のままとする'
                    End If
                Else
                    ten_over_judge = 10 '10より大きい値は10とする'
                End If
                goukei2 = goukei2 + ten_over_judge ' 自分の合計値の更新
                kaisu2 = kaisu2 + 1
            Case 2  '三回目
                Dim number3 As Integer = r.Next(1, 14)  '乱数生成
                ransu = number3.ToString    '乱数を変数ransuに代入

                Label10.Text = ransu     'ラベルに生成した乱数を表示

                printt(10, ransu)    'printt関数を呼び出しpictureboxに表面表示
                If Label6.Text = 1 Or Label7.Text = 1 Or Label8.Text = 1 Or Label9.Text = 1 Then ' これまでのカードに1が含まれている場合(今回引いたカードについての処理は下のIf文で処理)
                    If goukei2 + Label10.Text > 21 Then ' 1があり、かつ、この条件が真ならば、一つでも1を11として扱うと、バーストするので、1はすべて1として扱う(If文内で再計算する)
                        goukei2 = Integer.Parse(Label6.Text) + Integer.Parse(Label7.Text) + Integer.Parse(Label8.Text) + Integer.Parse(Label9.Text) ' 1を1として合計値を再計算
                    End If
                End If
                If Label10.Text <= 10 Then '10以下の場合'
                    If Label10.Text = 1 And goukei2 + 11 <= 21 Then '3枚目が1の場合であり、かつ、これまでのカードとの合計が21以下の場合'
                        ten_over_judge = 11 '三枚目のカードである1を11とする'
                    Else
                        ten_over_judge = Label10.Text '1を1のままとする'
                    End If
                Else
                    ten_over_judge = 10 '10より大きい値は10とする'
                End If
                goukei2 = goukei2 + ten_over_judge ' 自分の合計値の更新
                kaisu2 = kaisu2 + 1
            Case 3  '四回目以降
                Dim Answer As MsgBoxResult
                Answer = MsgBox("これ以上HITできません" & vbCrLf & " STANDを押してください", MsgBoxStyle.OkOnly, "error")

        End Select
        Label12.Text = goukei2
        Label13.Text = kaisu2

        If goukei2 > 21 Then    '自分の合計が21を上回っている場合
            store.Label3.Text = Label6.Text
            store.Label4.Text = Label7.Text
            store.keep() ' storeフォームのkeep関数を呼び出す
            answer2 = MsgBox("     あなたの負けです" & vbCrLf & "     もう一度しますか？", MsgBoxStyle.YesNo, "バースト")
            roopcount += 1 ' インクリメント(必ず2になる)
            store.roop1 = roopcount ' roopcountの値をstoreフォームのroop1に代入
            store.roop() ' storeフォームのroop関数を呼び出す

            finishicode = 1

            If answer2 = vbYes Then ' 
                f1.Show() ' Mainフォームを表示
                My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
                Me.Close() ' 今開いているフォームを閉じる
            Else
                probability = store.count21 * 100 / store.roop2 ' ブラックジャックの出現確率計算
                answer2 = MsgBox("本当に閉じますか？" & vbCrLf & "今回のブラックジャック出現率(%)" & probability, MsgBoxStyle.YesNo + vbExclamation, "確認") ' MsgBoxの表示と、結果をanswer2に代入
                If answer2 = vbYes Then ' Yesの場合
                    Me.Close() ' 今開いているフォームを閉じる
                Else
                    f1.Show() ' Mainフォームを表示
                    My.Application.ApplicationContext.MainForm = f1 ' Mainフォームをメインフォームにする処理
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Public Sub printt(ByVal Labelnumber, ByVal alllabel)    '引数（labelの番号,labelに入った数字)


        Dim r As New Random

        Dim SHDC As Integer = r.Next(1, 5)  '乱数生成とSDHCへの代入
        Dim PBoxnumber As PictureBox
        PBoxnumber = PictureBox1 ' 初期化(直ぐに引数で指定されたLabelnumberに沿ったPictureBox[1-9]+が入り、上書きされる。, NULL参照の例外が発生する確率を無くすために初期化している)

        If Labelnumber = 1 Then         'Lavel1のときPictureBox1
            PBoxnumber = PictureBox1
        ElseIf Labelnumber = 2 Then     'Lavel2のときPictureBox11
            PBoxnumber = PictureBox11
        ElseIf Labelnumber = 3 Then     'Lavel3のときPictureBox3
            PBoxnumber = PictureBox3
        ElseIf Labelnumber = 4 Then     'Lavel4のときPictureBox4
            PBoxnumber = PictureBox4
        ElseIf Labelnumber = 5 Then     'Lavel5のときPictureBox5
            PBoxnumber = PictureBox5
        ElseIf Labelnumber = 6 Then     'Lavel6のときPictureBox6
            PBoxnumber = PictureBox6
        ElseIf Labelnumber = 7 Then     'Lavel7のときPictureBox7
            PBoxnumber = PictureBox7
        ElseIf Labelnumber = 8 Then     'Lavel8のときPictureBox8
            PBoxnumber = PictureBox8
        ElseIf Labelnumber = 9 Then     'Lavel9のときPictureBox9
            PBoxnumber = PictureBox9
        ElseIf Labelnumber = 10 Then    'Lavel10のときPictureBox10
            PBoxnumber = PictureBox10
        End If


        If SHDC = 1 Then    'スペードのとき
            If alllabel = 1 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s01.png")
            ElseIf alllabel = 2 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s02.png")
            ElseIf alllabel = 3 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s03.png")
            ElseIf alllabel = 4 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s04.png")
            ElseIf alllabel = 5 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s05.png")
            ElseIf alllabel = 6 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s06.png")
            ElseIf alllabel = 7 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s07.png")
            ElseIf alllabel = 8 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s08.png")
            ElseIf alllabel = 9 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s09.png")
            ElseIf alllabel = 10 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s10.png")
            ElseIf alllabel = 11 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s11.png")
            ElseIf alllabel = 12 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s12.png")
            ElseIf alllabel = 13 Then
                PBoxnumber.Image = Image.FromFile(".\picture\s13.png")
            End If
        End If

        If SHDC = 2 Then    'ハートのとき
            If alllabel = 1 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h01.png")
            ElseIf alllabel = 2 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h02.png")
            ElseIf alllabel = 3 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h03.png")
            ElseIf alllabel = 4 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h04.png")
            ElseIf alllabel = 5 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h05.png")
            ElseIf alllabel = 6 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h06.png")
            ElseIf alllabel = 7 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h07.png")
            ElseIf alllabel = 8 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h08.png")
            ElseIf alllabel = 9 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h09.png")
            ElseIf alllabel = 10 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h10.png")
            ElseIf alllabel = 11 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h11.png")
            ElseIf alllabel = 12 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h12.png")
            ElseIf alllabel = 13 Then
                PBoxnumber.Image = Image.FromFile(".\picture\h13.png")
            End If
        End If

        If SHDC = 3 Then    'ダイヤのとき
            If alllabel = 1 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d01.png")
            ElseIf alllabel = 2 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d02.png")
            ElseIf alllabel = 3 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d03.png")
            ElseIf alllabel = 4 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d04.png")
            ElseIf alllabel = 5 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d05.png")
            ElseIf alllabel = 6 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d06.png")
            ElseIf alllabel = 7 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d07.png")
            ElseIf alllabel = 8 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d08.png")
            ElseIf alllabel = 9 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d09.png")
            ElseIf alllabel = 10 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d10.png")
            ElseIf alllabel = 11 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d11.png")
            ElseIf alllabel = 12 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d12.png")
            ElseIf alllabel = 13 Then
                PBoxnumber.Image = Image.FromFile(".\picture\d13.png")
            End If
        End If

        If SHDC = 4 Then    'クラブのとき
            If alllabel = 1 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c01.png")
            ElseIf alllabel = 2 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c02.png")
            ElseIf alllabel = 3 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c03.png")
            ElseIf alllabel = 4 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c04.png")
            ElseIf alllabel = 5 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c05.png")
            ElseIf alllabel = 6 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c06.png")
            ElseIf alllabel = 7 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c07.png")
            ElseIf alllabel = 8 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c08.png")
            ElseIf alllabel = 9 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c09.png")
            ElseIf alllabel = 10 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c10.png")
            ElseIf alllabel = 11 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c11.png")
            ElseIf alllabel = 12 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c12.png")
            ElseIf alllabel = 13 Then
                PBoxnumber.Image = Image.FromFile(".\picture\c13.png")
            End If
        End If



    End Sub

    Private Sub ToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem.Click 'ToolStripMenuItemがクリックされた時に発生するイベントプロシージャ
        Dim dialog As New ChildDialog ' ChildDialogを宣言
        dialog.Show() ' ChildDialogをモーダレスとして表示
    End Sub
End Class
