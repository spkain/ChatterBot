Public Class CharaSelector

    Private Shared _Instance As CharaSelector

    Private Sub New()

    End Sub

    Public Shared Function CreateInstance() As CharaSelector
        If IsNothing(_Instance) Then
            _Instance = New CharaSelector
        End If
        Return _Instance
    End Function

    Public Function CreateChara() As Mascot
        Console.WriteLine("キャラクターを選択してください")
        Console.WriteLine("0:つんでれ 1:わがまま 2:せいじゅんは 3:むしん 4:じゅんじゅんは 5:選択をやめる")
        Dim selNo As Integer
        Try
            selNo = Int32.Parse(Console.ReadLine())
        Catch
            selNo = EnumCharactor.JUUJUN
        End Try

        If selNo = 5 Then
            Console.WriteLine("終了します")
            Environment.Exit(0)
        End If

        Dim aName As String
        Do
            Console.Write("名前: ")
            aName = Console.ReadLine()

            If (aName = Nothing Or Len(aName) = 0) Then
                Console.WriteLine()
            End If
        Loop While (aName = Nothing Or Len(aName) = 0)

        Return GetInstanceOfChara(aName, selNo)

    End Function


    Private Function GetInstanceOfChara(ByVal aName As String, ByVal chara As EnumCharactor) As Mascot

        Select Case chara
            Case EnumCharactor.JUUJUN
                Return New MascotJuujun(aName)
            Case EnumCharactor.MUSIN
                Return New MascotMusin(aName)
            Case EnumCharactor.SEIJUN
                Return New MascotSeijun(aName)
            Case EnumCharactor.WAGAMAMA
                Return New MascotWagamama(aName)
            Case EnumCharactor.TUNDERE
                Return New Mascottundere(aName)
        End Select
        Return New MascotJuujun(aName)
    End Function

End Class
