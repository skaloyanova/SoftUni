using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo;

public class Repo
{
    public int id { get; set; }
    public string full_name { get; set; }
    public string html_url { get; set; }

    public override string ToString()
    {
        return $"id: {id} || name: {full_name} || {html_url}";
    }
}
