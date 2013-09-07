Module MainModule
    Private mas As Mascot

    Sub Main()
        Console.WriteLine("コンソールマスコット")
        Console.WriteLine()
        Console.WriteLine("---------------------------------------------")
        Console.WriteLine()

        Dim selChara As CharaSelector = CharaSelector.CreateInstance
        mas = selChara.CreateChara
        mas.LineOut()
        MainLoop()

    End Sub

    Sub MainLoop()
        While (True)
            mas.MenuChoise()
        End While
    End Sub


End Module
