Public Class store 'ファイル名store,識別コードstoreのクラス
    Public count As String ' ブラックジャックの数をカウントするための変数countを文字型で宣言
    Public zero As String ' Label2の中身を0にするために用いる変数zeroを文字型で宣言
    Public count21 As String ' カウントしたブラックジャックの最終的な数をLabel2.Textに保存するのに用いる変数count21を文字型で宣言
    Public roop1 As Integer ' ゲーム全体を終わるまでに何回ゲームをしたかをカウントしておくための変数roop1を整数型で宣言
    Public roop2 As Integer ' カウントしたゲームのループ回数の最終的な値を保存しておくための変数をroop2を整数型で宣言
    Private Sub store_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load ' storeフォームを読み込んだ時の処理
        count = 1 ' 1を代入
        zero = 0 ' 0を代入
        roop1 = 0 ' 0を代入
        roop2 = 0 ' 0を代入
        Label2.Text = 0 ' 0を代入
    End Sub
    Public Sub keep() ' ブラックジャックの回数を数えるための関数
        Dim one As String ' 1を表すためのoneを文字型で宣言
        Dim ten As String ' 10を表すためのtenを文字型で宣言
        Dim eleven As String ' 11を表すためのelevenを文字型で宣言
        Dim twelve As String ' 12を表すためのtwelveを文字型で宣言
        Dim thirteen As String ' 13を表すためのthirteenを文字型で宣言
        one = 1 ' 1を代入
        ten = 10 ' 10を代入
        eleven = 11 ' 11を代入
        twelve = 12 ' 12を代入
        thirteen = 13 ' 13を代入

        ' 初めの自分の手札が1と10になりえる値(10,11,12,13)かどうか
        ' 上のコメントの条件を満たす場合、ブラックジャックの数を保存しておくための変数をインクリメント
        If Label3.Text = one And Label4.Text = ten Then
            If Main.batucount = 0 Then ' 今回のフォームで×ボタンが一回も押されていないかどうか
                If Label2.Text = zero Then ' プログラム終了までに出たブラックジャックの数がzero(0)かどうか
                    Label2.Text = count ' count(1)を代入
                Else
                    Label2.Text = count + 1 ' count+1を代入
                End If
            End If
            count21 = Label2.Text ' Label2に保存しておいたプログラム終了までに出たブラックジャックの数をcount21に代入
        End If
        If Label3.Text = one And Label4.Text = eleven Then
            If Main.batucount = 0 Then
                If Label2.Text = zero Then
                    Label2.Text = count
                Else
                    Label2.Text = count + 1
                End If
            End If
            count21 = Label2.Text
        End If
        If Label3.Text = one And Label4.Text = twelve Then
            If Main.batucount = 0 Then
                If Label2.Text = zero Then
                    Label2.Text = count
                Else
                    Label2.Text = count + 1
                End If
            End If
            count21 = Label2.Text
        End If
        If Label3.Text = one And Label4.Text = thirteen Then
            If Main.batucount = 0 Then
                If Label2.Text = zero Then
                    Label2.Text = count
                Else
                    Label2.Text = count + 1
                End If
            End If
            count21 = Label2.Text
        End If
        If Label3.Text = ten And Label4.Text = one Then
            If Main.batucount = 0 Then
                If Label2.Text = zero Then
                    Label2.Text = count
                Else
                    Label2.Text = count + 1
                End If
            End If
            count21 = Label2.Text
        End If
        If Label3.Text = eleven And Label4.Text = one Then
            If Main.batucount = 0 Then
                If Label2.Text = zero Then
                    Label2.Text = count
                Else
                    Label2.Text = count + 1
                End If
            End If
            count21 = Label2.Text
        End If
        If Label3.Text = twelve And Label4.Text = one Then
            If Main.batucount = 0 Then
                If Label2.Text = zero Then
                    Label2.Text = count
                Else
                    Label2.Text = count + 1
                End If
            End If
            count21 = Label2.Text
        End If
        If Label3.Text = thirteen And Label4.Text = one Then
            If Main.batucount = 0 Then
                If Label2.Text = zero Then
                    Label2.Text = count
                Else
                    Label2.Text = count + 1
                End If
            End If
            count21 = Label2.Text
        End If
    End Sub
    Public Sub roop() ' Mainフォームで使う、ゲーム全体を終わるまでに何回ゲームをしたかを数えるための関数
        If Main.batucount = 0 Then ' 今のフォームが×ボタンが押された事のあるフォームかどうか
            roop2 = roop2 + roop1 - 1 ' ゲーム全体を終えるまでにしたプレイ回数をroop2に代入
        End If
    End Sub
End Class