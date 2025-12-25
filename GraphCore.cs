using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GraphCore
{
    public int n;                        
    public int[][] vertex;               
    public int max;                       
    public int[][] num_reb;               
    public int[][] max_mas;                
    public int[] vis;                      
    public int[] set_arr;                 
    public List<int[]> most_set;           
    public int most_step;                  
    public int sled;                       

    public GraphCore(int size)
    {
        n = size;
        vertex = new int[n][];
        for (int i = 0; i < n; i++) vertex[i] = new int[n];
        most_set = new List<int[]>();
        most_step = 0;
        sled = 0;
    }

    public void MatrixInc()
    {
        
        max = 0;
        for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
                if (vertex[i][j] == 1) max++;

        num_reb = new int[3][];
        for (int i = 0; i < 3; i++) num_reb[i] = new int[max];

        max_mas = new int[max][];
        for (int i = 0; i < max; i++) max_mas[i] = new int[max];

        int iter = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                if (vertex[i][j] == 1)
                {
                    num_reb[0][iter] = iter;
                    num_reb[1][iter] = i;
                    num_reb[2][iter] = j;
                    iter++;
                }
            }
        }

        for (int i = 0; i < max; i++)
            for (int j = i + 1; j < max; j++)
                if (num_reb[1][i] == num_reb[1][j] || num_reb[1][i] == num_reb[2][j] ||
                    num_reb[2][i] == num_reb[1][j] || num_reb[2][i] == num_reb[2][j])
                {
                    max_mas[i][j] = 1;
                    max_mas[j][i] = 1;
                }
    }

    public void Most(int start)
    {
        vis = new int[max];
        set_arr = new int[max];

        for (int i = 0; i < vis.Length; i++)
            vis[i] = 0;
        vis[start] = 1;
        set_arr[0] = start;
        sled = 0;

        for (int i = 0; i < max; i++)
        {
            if (max_mas[start][i] == 0 && vis[i] == 0)
            {
                int schet = 0;
                for (int j = 0; j <= sled; j++)
                    if (max_mas[set_arr[j]][i] == 0) schet++;

                if (schet == sled + 1)
                {
                    sled++;
                    set_arr[sled] = i;
                    vis[i] = 1;
                }
            }
        }

        if (sled > most_step)
        {
            most_step = sled;
            most_set.Clear();
            int[] best = new int[sled + 1];
            Array.Copy(set_arr, best, sled + 1);
            most_set.Add(best);
        }
    }

    public void FindMaximumMatching()
    {
        MatrixInc();
        most_set.Clear();
        most_step = 0;

        for (int i = 0; i < max; i++)
            Most(i);
    }
}
