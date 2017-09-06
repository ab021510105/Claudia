using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DataStates 的摘要说明
/// </summary>
/// 
[Serializable]
public  class DataStates
{
    public DataStates( )
    {

    }
    [Serializable]
    private class State
    {
        public object data;
        public State Next;
        public State Front;
        public void clear()
        {
            Next = null;
            data = null;
            Front = null;
        }

    }
    private  State head = null;
    private  State root = null;
    public int statecount = 0;
    public int stateindex = 0;
    public void Addstate(object Data)
    {
        if (head != null)
        {
            State p2 = root;
            root = new State();
            p2.Next = root;
            root.Next = null;
            root.Front = p2;
            root.data = Data;
        }
        else
        {
            root = head = new State();
            head.Front=head.Next = null;
            head.data = Data;
        }
        statecount++;
    }
    public object Readex(int _stateIndex)
    {
        if (head != null)
        {
            State p = head;
            for (int i = 1; i <= _stateIndex; i++)
            {
                if (p != null)
                    p = p.Next;
                else
                    return null;
            }
            if (p != null)
                return p.data;
            else
                return null;
        }
        else
        {
            return null;
        }
    }



    private State read=null;
    public object Read()
    {
        if (head != null)
        {
            
            if (read != null)
            {
                State readed = read;
                read = read.Next;
                if (read == null)
                {
                    return null;
                }
                stateindex++;
                return readed.data;
                
            }
            else
            {
                read = head.Next;
                return head.data;
            }
            
        }
        else
        {
            return null;
        }
    }

    public void Clear()
    {
        while (head != null)
        {
            State p1 = head.Next;
            head.clear();
            head = p1;
        }
        statecount = 0;
        stateindex = 0;
    }

    public void UpdateData(object Data, int index)
    {
        State p1 = head;
        for (int i = 1; i <= index; i++)
        {
            p1 = p1.Next;
        }
        p1.data = Data;
    }


    public void DeleteOneData(object Data)
    {
        if (head != null)
        {
            State p2 = head;

            while (p2 != null)
            {
                if (p2.data == Data)
                {
                    if (p2.Front == null)
                    {
                        if (p2.Next != null)
                        {
                            p2.Next.Front = null;
                        }
                            head = p2.Next;
                        p2.clear();
                    }
                    else if (p2.Next == null)
                    {
                        root=p2.Front;
                        p2.Front.Next = null;
                        p2.clear();
                    }
                    else
                    {
                        p2.Front.Next = p2.Next;
                        p2.Next.Front = p2.Front;
                        p2.clear();
                    }
                }
            }
            statecount--;
        }
    }

}