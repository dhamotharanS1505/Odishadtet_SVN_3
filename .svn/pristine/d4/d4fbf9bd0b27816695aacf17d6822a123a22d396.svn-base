using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Odishadtet.Models
{
    public class JQGridProcess
    {

    }
    #region JqGrid Property
    public class JQGrid
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public Array rows { get; set; }
    }
    public class Filter
    {
        public Int64 FilterMasterID { get; set; }
        public string FilterName { get; set; }

        //for JQgrid process 
        public GroupOp groupOp { get; set; }
        public List<Rule> rules { get; set; }
        public List<Filter> groups { get; set; }
    }
    public class Rule
    {
        public string field { get; set; }
        public Operations op { get; set; }
        public string data { get; set; }
    }
    public class JqSearchIn
    {
        public string sidx { get; set; }
        public string sord { get; set; }
        public int page { get; set; }
        public int rows { get; set; }
        public bool _search { get; set; }
        public string searchField { get; set; }
        public string searchOper { get; set; }
        public string searchString { get; set; }
        public string filters { get; set; }



        //added by hari dude to dunamic where query foramtion
        public string whereString { get; set; }
        public string ShortingQuery { get; set; }
        public int startPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecCount { get; set; }
        public int totalPages { get; set; }

        //end

        public JqSearchIn InitialiseObject(JqSearchIn si)
        {
            JqSearchIn si2 = new JqSearchIn();
            var serializer = new JavaScriptSerializer();
            //where Query
            si.whereString = si._search && !String.IsNullOrEmpty(si.filters) ? WhereClauseGenerator.CreateWhereQueryForLinq(serializer.Deserialize<Filter>(si.filters)).ToString() : String.Empty;
            //Shorting Query
            si.ShortingQuery = WhereClauseGenerator.CreateShortingQueryForLinq(si, true);
            si2 = si;
            return si2;
        }

        public IEnumerable<dynamic> SetObjectListDataInitialise(IEnumerable<dynamic> list, JqSearchIn si)
        {
            si.startPage = (si.page > 0 ? si.page - 1 : 0) * si.rows;
            si.PageSize = startPage + si.rows;
            si.TotalRecCount = list.Count();
            si.totalPages = (int)Math.Ceiling((float)TotalRecCount / si.rows);
            var CollectedList = list.Skip(startPage).Take(PageSize).ToList();
            return CollectedList;
        }
    }
    #endregion

    #region Class Generator
    public enum GroupOp
    {
        AND,
        OR
    }



    public enum Operations
    {
        eq, // "equal"
        ne, // "not equal"
        lt, // "less"
        le, // "less or equal"
        gt, // "greater"
        ge, // "greater or equal"
        bw, // "begins with"
        bn, // "does not begin with"
        //in, // "in"
        //ni, // "not in"
        ew, // "ends with"
        en, // "does not end with"
        cn, // "contains"
        nc  // "does not contain"
    }

    public enum OperationsLinq
    {
        eq, // "equal"
        //  ne, // "not equal"
        lt, // "less"
        le, // "less or equal"
        gt, // "greater"
        ge, // "greater or equal"
        bw, // "begins with"
        //bn, // "does not begin with"
        //in, // "in"
        //ni, // "not in"
        ew, // "ends with"
        //  en, // "does not end with"
        cn // "contains"
           //  nc  // "does not contain"

    }

    public class WhereClauseGenerator
    {


        private static readonly string[] FormatMapping = {
        "({0} = '{1}')",               // "eq" - equal
        "({0} <> {1})",                // "ne" - not equal
        "({0} < {1})",                 // "lt" - less than
        "({0} <= {1})",                // "le" - less than or equal to
        "({0} > {1})",                 // "gt" - greater than
        "({0} >= {1})",                // "ge" - greater than or equal to
        "({0} LIKE '{1}%')",           // "bw" - begins with
        "({0} NOT LIKE '{1}%')",       // "bn" - does not begin with
        "({0} LIKE '%{1}')",           // "ew" - ends with
        "({0} NOT LIKE '%{1}')",       // "en" - does not end with
        "({0} LIKE '%{1}%')",          // "cn" - contains
        "({0} NOT LIKE '%{1}%')"       // "nc" - does not contain
        //"({0} in '{1}%')",           // "in" - in
    };

        private static readonly string[] FormatMappingwithTableName = {
        "({0}.{1} = '{2}')",               // "eq" - equal
        "({0}.{1} <> {2})",                // "ne" - not equal
        "({0}.{1} < {2})",                 // "lt" - less than
        "({0}.{1} <= {2})",                // "le" - less than or equal to
        "({0}.{1} > {2})",                 // "gt" - greater than
        "({0}.{1} >= {2})",                // "ge" - greater than or equal to
        "({0}.{1} LIKE '{2}%')",           // "bw" - begins with
        "({0}.{1} NOT LIKE '{2}%')",       // "bn" - does not begin with
        "({0}.{1} LIKE '%{2}')",           // "ew" - ends with
        "({0}.{1} NOT LIKE '%{2}')",       // "en" - does not end with
        "({0}.{1} LIKE '%{2}%')",          // "cn" - contains
        "({0}.{1} NOT LIKE '%{2}%')"       // "nc" - does not contain
    };


        //(x.Fase != null && x.Fase.ToUpper().Contains(Item.Trim()))
        private static readonly string[] FormatMappingForLinq = {
        "({0} != null && {1} == \"{2}\")",               // "eq" - equal
        
        "({0} != null && {1} <> {2})",                // "ne" - not equal //dont user it if u want u have to change
        "({0} != null && {1} < {2})",                 // "lt" - less than 
        "({0} != null && {1} <= {2})",                // "le" - less than or equal to
        "({0} != null && {1} > {2})",                 // "gt" - greater than
        "({0} != null && {1} >= {2})",                // "ge" - greater than or equal to
        "({0} != null && {1}.StartsWith(\"{2}\"))",// "bw" - begins with added by hari
        "({0} != null && {1} NOT LIKE '{2}%')",       // "bn" - does not begin with //dont user it if u want u have to change
        "({0} != null && {1}.EndsWith(\"{2}\"))",  // "ew" - ends with
        "({0} != null && {1} NOT LIKE '%{2}')",       // "en" - does not end with //dont user it if u want u have to change
        "({0} != null && {1}.Contains(\"{2}\"))",  // "cn" - contains
        "({0} != null && {1} NOT LIKE '%{2}%')"       // "nc" - does not contain //dont user it if u want u have to change
      
    };



        private static StringBuilder ParseRule(ICollection<Rule> rules, GroupOp groupOp)
        {
            if (rules == null || rules.Count == 0)
                return null;

            var sb = new StringBuilder();
            bool firstRule = true;
            foreach (var rule in rules)
            {
                if (!firstRule)
                    // skip groupOp before the first rule
                    sb.Append(groupOp);
                else
                    firstRule = false;


                // new process added by hari
                //old code blocked
                //sb.AppendFormat(FormatMapping[(int)rule.op], rule.field, rule.data);
                if (rule.field.Contains("~"))
                {
                    string[] splitdata = rule.field.Split('~');
                    sb.AppendFormat(FormatMappingwithTableName[(int)rule.op], splitdata[0], splitdata[1], rule.data);
                }
                else
                {
                    sb.AppendFormat(FormatMapping[(int)rule.op], rule.field, rule.data);
                }
                // new process end by hari


            }
            return sb.Length > 0 ? sb : null;
        }

        private static void AppendWithBrackets(StringBuilder dest, StringBuilder src)
        {
            if (src == null || src.Length == 0)
                return;

            if (src.Length > 2 && src[0] != '(' && src[src.Length - 1] != ')')
            {
                dest.Append('(');
                dest.Append(src);
                dest.Append(')');
            }
            else
            {
                // verify that no other '(' and ')' exist in the b. so that
                // we have no case like src = "(x < 0) OR (y > 0)"
                for (int i = 1; i < src.Length - 1; i++)
                {
                    if (src[i] == '(' || src[i] == ')')
                    {
                        dest.Append('(');
                        dest.Append(src);
                        dest.Append(')');
                        return;
                    }
                }
                dest.Append(src);
            }
        }

        private static StringBuilder ParseFilter(ICollection<Filter> groups, GroupOp groupOp)
        {
            if (groups == null || groups.Count == 0)
                return null;

            var sb = new StringBuilder();
            bool firstGroup = true;
            foreach (var group in groups)
            {
                var sbGroup = CreateWhereQueryForSQL(group);
                if (sbGroup == null || sbGroup.Length == 0)
                    continue;

                if (!firstGroup)
                    // skip groupOp before the first group
                    sb.Append(groupOp);
                else
                    firstGroup = false;

                sb.EnsureCapacity(sb.Length + sbGroup.Length + 2);
                AppendWithBrackets(sb, sbGroup);
            }
            return sb;
        }

        public static StringBuilder CreateWhereQueryForSQL(Filter filters)
        {
            var parsedRules = ParseRule(filters.rules, filters.groupOp);
            var parsedGroups = ParseFilter(filters.groups, filters.groupOp);

            if (parsedRules != null && parsedRules.Length > 0)
            {
                if (parsedGroups != null && parsedGroups.Length > 0)
                {
                    var groupOpStr = filters.groupOp.ToString();
                    var sb = new StringBuilder(parsedRules.Length + parsedGroups.Length + groupOpStr.Length + 4);
                    AppendWithBrackets(sb, parsedRules);
                    sb.Append(groupOpStr);
                    AppendWithBrackets(sb, parsedGroups);
                    return sb;
                }
                return parsedRules;
            }
            return parsedGroups;
        }


        //dont mofify please

        // code created by hari if u going to edit get a conformation from me
        public static StringBuilder CreateWhereQueryForLinq(Filter filters)
        {
            var parsedRules = ParseRuleForLinq(filters.rules, filters.groupOp);
            var parsedGroups = ParseFilterForLinq(filters.groups, filters.groupOp);

            if (parsedRules != null && parsedRules.Length > 0)
            {
                if (parsedGroups != null && parsedGroups.Length > 0)
                {
                    var groupOpStr = filters.groupOp.ToString();
                    var sb = new StringBuilder(parsedRules.Length + parsedGroups.Length + groupOpStr.Length + 4);
                    AppendWithBrackets(sb, parsedRules);
                    sb.Append(groupOpStr);
                    AppendWithBrackets(sb, parsedGroups);
                    return sb;
                }
                return parsedRules;
            }
            return parsedGroups;
        }

        // code created by hari if u going to edit get a conformation from me
        private static StringBuilder ParseRuleForLinq(ICollection<Rule> rules, GroupOp groupOp)
        {
            // for linq process i changes operators
            string groupOpLinqValue = "";
            string G = groupOp.ToString();
            if (G == "OR")
                groupOpLinqValue = " || ";
            else
                groupOpLinqValue = " && ";

            if (rules == null || rules.Count == 0)
                return null;

            var sb = new StringBuilder();
            bool firstRule = true;

            foreach (var rule in rules)
            {
                if (!firstRule)
                    // skip groupOp before the first rule
                    sb.Append(groupOpLinqValue);
                else
                    firstRule = false;


                // new process added by hari

                string FilterColumn = rule.field;
                string FilterNullColumn = rule.field;
                string FilterOp = rule.op.ToString();
                if (FilterOp == "eq" || FilterOp == "bw" || FilterOp == "ew" || FilterOp == "cn" || FilterOp == "ge" || FilterOp == "le")
                {

                    if (rule.field.Contains('~')) //if it is (bool~shorting
                    {
                        //e.SomeFlag ? 0 : 1
                        string[] S = rule.field.Split('~');
                        string splitProperty = S[0];
                        string ValidationDataType = S[1];

                        if (ValidationDataType == "0") //Bool
                        {
                            // sortField = "" + splitProperty + "? 0:1 " + si.sord;
                        }
                        if (ValidationDataType.ToUpper() == "DATE") //date
                        {

                            //DateTime D1;
                            //D1 = DateTime.ParseExact(rule.data, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                            //string Y, M, D;
                            //Y = D1.Year.ToString();
                            //M = D1.Month.ToString();
                            //D = D1.Day.ToString();

                            //FilterNullColumn = S[0];
                            //FilterColumn = S[0];

                            //if (FilterOp == "ge")
                            //{
                            //    string ForT = "DateTime(" + Y + "," + M + "," + D + ",00,00,00)";
                            //    sb.AppendFormat(splitProperty + " >=" + ForT);
                            //}
                            //else if (FilterOp == "le")
                            //{
                            //    string ForT = "DateTime(" + Y + "," + M + "," + D + ", 23,59,59)";
                            //    sb.AppendFormat(splitProperty + " <=" + ForT);
                            //}
                            //else if (FilterOp == "eq")
                            //{

                            //    string ForT = "DateTime(" + Y + "," + M + "," + D + ",00,00,00)";
                            //    string ForT2 = "DateTime(" + Y + "," + M + "," + D + ", 23,59,59)";
                            //    sb.AppendFormat("("+splitProperty + " >=" + ForT +" && ");
                            //    sb.AppendFormat(splitProperty + " <=" + ForT2+")");

                            //}



                            DateTime D2;
                            D2 = DateTime.ParseExact(rule.data, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            Int64 D1 = Convert.ToInt64(string.Format("{0:yyyyMMdd}", D2));
                            FilterNullColumn = S[0];
                            FilterColumn = S[0];
                            if (FilterOp == "eq")
                            {
                                 sb.AppendFormat(splitProperty + "==" + D1);
                                //string s = "convert(datetime, {0}) >= {1}" + splitProperty + ")==" + D1;
                                //sb.AppendFormat(s);
                                
                            }
                            else
                            {
                                sb.AppendFormat(FormatMappingForLinq[(int)rule.op], FilterNullColumn, FilterColumn, D1);
                            }

                        }
                        else
                        {
                            // sortField = splitProperty + " " + si.sord;
                        }

                    }
                    else
                    {
                        if (rule.field.Contains('.'))
                        {
                            string[] S = rule.field.Split('.');
                            FilterNullColumn = S[0];
                        }
                        FilterColumn = rule.field + ".ToUpper()";
                        sb.AppendFormat(FormatMappingForLinq[(int)rule.op], FilterNullColumn, FilterColumn, rule.data.ToUpper());
                    }
                }

                //sb.AppendFormat(FormatMappingForLinq[(int)rule.op], FilterNullColumn, FilterColumn, rule.data.ToUpper());

                // new process end by hari


            }
            return sb.Length > 0 ? sb : null;
        }
        // code created by hari if u going to edit get a conformation from me
        private static StringBuilder ParseFilterForLinq(ICollection<Filter> groups, GroupOp groupOp)
        {
            if (groups == null || groups.Count == 0)
                return null;

            var sb = new StringBuilder();
            bool firstGroup = true;
            foreach (var group in groups)
            {
                var sbGroup = CreateWhereQueryForLinq(group);
                if (sbGroup == null || sbGroup.Length == 0)
                    continue;

                if (!firstGroup)
                    // skip groupOp before the first group
                    sb.Append(groupOp);
                else
                    firstGroup = false;

                sb.EnsureCapacity(sb.Length + sbGroup.Length + 2);
                AppendWithBrackets(sb, sbGroup);
            }
            return sb;
        }


        // code created by hari if u going to edit get a conformation from me
        public static String CreateShortingQueryForLinq(JqSearchIn si, bool isNullable)
        {
            string sortField = "";
            //for Tree view it take all groupping coumn as shorting Colum so tempe i added this query for do that process
            if (!string.IsNullOrEmpty(si.sidx))
            {
                if (si.sidx.Contains(','))
                {
                    string[] Spt = si.sidx.Split(',');
                    int lastcount = Spt.Count();
                    si.sidx = "";              
                    
                       // si.sidx = string.Join(",", Spt);
                        si.sidx = Spt[lastcount - 1];
                        si.sidx = si.sidx.Replace("asc", "").Replace("desc","");
                    
                    
                }


                if (!isNullable)
                {
                    sortField = si.sidx + " " + si.sord;
                }
                else
                {

                    //New by hari

                    if (si.sidx.Contains('~')) //if it is (bool~shorting
                    {
                        //e.SomeFlag ? 0 : 1
                        string[] S = si.sidx.Split('~');
                        string splitProperty = S[0];
                        string ValidationDataType = S[1];

                        if (ValidationDataType == "0") //Bool
                        {
                            sortField = "" + splitProperty + "? 0:1 " + si.sord;
                        }
                        if (ValidationDataType.ToUpper() == "DATE") //date
                        {
                            sortField = splitProperty + " " + si.sord;
                        }
                        else //Date
                        {
                            sortField = splitProperty + " " + si.sord;
                        }

                    }
                    else
                    {

                        //first check it contain (.) if not exist no need to split the process
                        if (si.sidx.Contains('.'))
                        {
                            //split the Dot get the first value
                            string[] S = si.sidx.Split('.');
                            string splitProperty = S[0];
                            sortField = "iif(" + splitProperty + "==null,null," + si.sidx + ")  " + si.sord;

                        }

                        else
                        // if dot not exist set normal
                        {
                            sortField = "iif(" + si.sidx + "==null,null," + si.sidx + ")  " + si.sord;
                        }
                    }
                }
            }

            return sortField;
        }

    }
    #endregion
}