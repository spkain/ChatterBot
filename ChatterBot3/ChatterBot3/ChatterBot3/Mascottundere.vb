Public Class Mascottundere
    Inherits Mascot

    Private learnOKCount As Integer = 0
    Private learnOKMaxCount As Integer
    Private rndLearn As New Random
    Private sayOKCount As Integer = 0
    Private sayOKMaxCount As Integer

    Private Sub resetLearnOKCount()
        learnOKMaxCount = rndLearn.Next(2)
    End Sub

    Private Sub resetSayOKCount()
        sayOKMaxCount = rndLearn.Next(3)
    End Sub

    Public Sub New(ByVal aName As String)
        MyBase.New(aName)
        resetLearnOKCount()
        resetSayOKCount()
    End Sub

    Public Overrides Sub CommandPerformBeginSay()
        'Nothing
    End Sub

    Public Overrides Sub CommandPerformEndSay()
        'Nothing
    End Sub

    Public Overrides Sub EndProcBegin()
        MascotSay("えっなに///")
        MascotSay("じゃ、もうしらないっ///")
    End Sub

    Public Overrides Sub ErrorFullOverFlowListSay()
        MascotSay("もう、、、やだよ///")
    End Sub

    Public Overrides Sub ErrorNullSay()
        MascotSay("何いれてるんですか！！")
        MascotSay("即通報ですねー")
    End Sub

    Public Overrides Sub ErrorZeroLearnWordSay()
        MascotSay("何覚えさせようとしてるんですが、まだ覚えられると思っているんですか？")
        MascotSay("どんだけ暇なんですか！？")
    End Sub

    Public Overrides Sub Hello()
        MascotSay("一応あたしは、{0}なんですけど何か？", Name)
    End Sub

    Public Overrides Sub Learn()

        If learnOKCount < learnOKMaxCount Then
            MascotSay("覚えると思った？")
            learnOKCount = learnOKCount + 1
            Exit Sub
        End If

        If IsOK() Then
            MyBase.Learn()
        Else
            MascotSay("今忙しいの！")
        End If
        resetLearnOKCount()
        learnOKCount = 0
    End Sub

    Private Function IsOK() As Boolean
        'つかれた・・・
        Return True
    End Function

    Public Overrides Sub LearnBeginSay()
        MascotSay("いいよ、おぼえてあげる")
        MascotSay("なんですか？")
    End Sub

    Public Overrides Sub LearnEndSay()
        MascotSay("終わりだからね！")
    End Sub

    Public Overrides Sub LearnSuccessSay()
        MascotSay("{0}覚えたよ///", SelMaxWord)
    End Sub

    Public Overrides ReadOnly Property MaxListCount As Integer
        Get
            Return 5
        End Get
    End Property

    Public Overrides Sub Perform()
        MascotSay("あっちにいってよね！")
        MascotSay("今、メール打ってるから！")
    End Sub

    Public Overrides Sub Say()
        If sayOKCount < sayOKMaxCount Then
            MascotSay("いうと思った？")
            sayOKCount = sayOKCount + 1
            Exit Sub
        Else
            If (LearnCount <> 0) Then
                MascotSay("しょうがないね、ほらっ{0}　だよ", SelWord)
            End If
            resetSayOKCount()
            sayOKCount = 0
        End If
    End Sub
End Class
