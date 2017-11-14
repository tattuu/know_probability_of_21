Public Class ChildDialog ' ファイル名Childform,識別コードChildoDialogのクラス
    Private Sub ChildDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load 'ChildoDialogを読み込んだ時の処理
        ' 以下の文字列はLabel1.Textに代入する文字列
        Label1.Text = "(このゲームの)ブラックジャックの説明" _
                  & vbCrLf & "1. 合計が21(ブラックジャック)になった方の、" _
                  & vbCrLf & "　 勝ちとなりならなかった場合は、21に近い方" _
                  & vbCrLf & "　 の勝ちで、同じ数字の場合は引き分け" _
                  & vbCrLf & "2. 合計が21を先に超えた方の負け" _
                  & vbCrLf & "3. 11～13は10とみなす" _
                  & vbCrLf & "4. コンピュータは合計が17未満の場合、17以上" _
                  & vbCrLf & "　 になるまで引き続けなければならない"
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click ' Button1がクリックされたときの処理
        Me.Close() ' このフォームを閉じる
    End Sub
End Class