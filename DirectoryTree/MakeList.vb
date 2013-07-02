Imports System.IO

Public Class MakeList
    ''' <summary>
    ''' 获取指定路径下的所有目录
    ''' </summary>
    ''' <param name="myPath">指定路径</param>
    ''' <returns>指定路径下的所有目录</returns>
    ''' <remarks>不含子目录</remarks>
    Public Function GetCurrentDirectories(myPath As String) As String()
        Return Directory.GetDirectories(myPath)
    End Function
    ''' <summary>
    ''' 获取指定路径下的所有文件
    ''' </summary>
    ''' <param name="myPath">指定路径</param>
    ''' <returns>指定路径下的所有文件</returns>
    ''' <remarks>不含子目录中的文件</remarks>
    Public Function GetCurrentFiles(myPath As String) As String()
        Return Directory.GetFiles(myPath)
    End Function
    ''' <summary>
    ''' 获取指定路径下的所有目录
    ''' </summary>
    ''' <param name="myPath">指定路径</param>
    ''' <returns>指定路径下的所有目录</returns>
    ''' <remarks>含子目录</remarks>
    Public Function GetAllDirectoryList(myPath As String) As List(Of String)
        Dim ret As New List(Of String)
        Dim myCurrentDirectories() As String = GetCurrentDirectories(myPath)
        For i = 0 To myCurrentDirectories.Count - 1
            ret.Add(myCurrentDirectories(i))
            ret.AddRange(GetAllDirectoryList(myCurrentDirectories(i)))
        Next
        Return ret
    End Function
    ''' <summary>
    ''' 获取指定路径下的所有目录
    ''' </summary>
    ''' <param name="myPath">指定路径</param>
    ''' <returns>指定路径下的所有目录</returns>
    ''' <remarks>含子目录</remarks>
    Public Function GetAllDirectory(myPath As String) As String()
        Return GetAllDirectoryList(myPath).ToArray
    End Function
    ''' <summary>
    ''' 获取指定路径下的所有文件
    ''' </summary>
    ''' <param name="myPath">指定路径</param>
    ''' <returns>指定路径下的所有文件</returns>
    ''' <remarks>含子目录中的文件</remarks>
    Public Function GetAllFileList(myPath As String) As List(Of String)
        Dim ret As New List(Of String)
        Dim myCurrentFiles() As String = GetCurrentFiles(myPath)
        For i = 0 To myCurrentFiles.Count - 1
            ret.Add(myCurrentFiles(i))
        Next
        Dim myCurrentDirectories() As String = GetCurrentDirectories(myPath)
        For i = 0 To myCurrentDirectories.Count - 1
            ret.AddRange(GetAllFileList(myCurrentDirectories(i)))
        Next
        Return ret
    End Function
    ''' <summary>
    ''' 获取指定路径下的所有文件
    ''' </summary>
    ''' <param name="myPath">指定路径</param>
    ''' <returns>指定路径下的所有文件</returns>
    ''' <remarks>含子目录中的文件</remarks>
    Public Function GetAllFile(myPath As String) As String()
        Return GetAllFileList(myPath).ToArray
    End Function
    ''' <summary>
    ''' 获取指定路径下的所有目录和文件
    ''' </summary>
    ''' <param name="myPath">指定路径</param>
    ''' <param name="order">是否按层次遍历</param>
    ''' <returns>指定路径下的所有目录和文件</returns>
    ''' <remarks>含子目录中的目录和文件</remarks>
    Public Function GetAllPathList(myPath As String, Optional order As Boolean = False) As List(Of String)
        Dim ret As New List(Of String)
        If order Then
            Dim myCurrentFiles() As String = GetCurrentFiles(myPath)
            For i = 0 To myCurrentFiles.Count - 1
                ret.Add(myCurrentFiles(i))
            Next
            Dim myCurrentDirectories() As String = GetCurrentDirectories(myPath)
            For i = 0 To myCurrentDirectories.Count - 1
                ret.Add(myCurrentDirectories(i))
                ret.AddRange(GetAllFileList(myCurrentDirectories(i)))
            Next
        Else
            '先目录后文件
            ret.AddRange(GetAllDirectoryList(myPath))
            ret.AddRange(GetAllFileList(myPath))
        End If
        Return ret
    End Function
End Class
