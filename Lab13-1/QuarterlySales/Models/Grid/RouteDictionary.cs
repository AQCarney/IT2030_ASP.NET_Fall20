﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class RouteDictionary : Dictionary<string, string>
    {
        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }
        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }
        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string YearFilter
        {
            get => Get(nameof(SalesGridDTO.Year));
            set => this[nameof(SalesGridDTO.Year)] = value;
        }

        public string QuarterFilter
        {
            get => Get(nameof(SalesGridDTO.Quarter));
            set => this[nameof(SalesGridDTO.Quarter)] = value;
        }
        public string EmployeeFilter
        {
            get
            {
                string s = Get(nameof(SalesGridDTO.Employee));
                int index = s?.IndexOf('-') ?? -1;

                return index == -1 ? s : s.Substring(0, index);
            }
            set => this[nameof(SalesGridDTO.Employee)] = value;
        }
        private string Get(string key) => Keys.Contains(key)? this[key] : null;

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;
            if(string.Equals(current.SortField, fieldName, StringComparison.InvariantCultureIgnoreCase)
                && current.SortDirection=="asc")
            {
                this[nameof(GridDTO.SortDirection)] = "desc";
            }
            else
            {
                this[nameof(GridDTO.SortDirection)] = "asc";
            }
        }
        public void ClearFilters() => EmployeeFilter = YearFilter = QuarterFilter = SalesGridDTO.DefaultFilter;

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}
