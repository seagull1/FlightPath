using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flightpath.api.Models
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public class AirportDto : IComparable<AirportDto>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double LengthStartMiddle { get; set; }
        public double LengthMiddleEnd { get; set; }

        public int CompareTo(AirportDto other)
        {
            return LengthStartMiddle.CompareTo(other.LengthStartMiddle);
        }

        // Only apply to FlyingNode，list all properties that can sort
        public enum SortField
        {
            Id, LengthStartMiddle, LengthMiddleEnd
        }

        // Only apply to FlyingNode, name sort property and sort direction
        public struct Sorter
        {
            public SortField Field;
            public SortDirection Direction;

            public Sorter(SortField field, SortDirection direction)
            {
                Field = field;
                Direction = direction;
            }

            public Sorter(SortField field)
            {
                Field = field;
                Direction = SortDirection.Ascending;
            }
        }

        // define sort property and sort direction
        public static NodeComparer GetComparer(SortField field, SortDirection direction)
        {
            var list = new List<Sorter>();
            var sorter = new Sorter(field, direction);
            list.Add(sorter);
            return new NodeComparer(list);
        }

        //define sort property
        public static NodeComparer GetComparer(SortField field)
        {
            return GetComparer(field, SortDirection.Ascending);
        }

        // Default sort by ID 
        public static NodeComparer GetComparer()
        {
            return GetComparer(SortField.Id, SortDirection.Ascending);
        }

        // define sorter list
        public static NodeComparer GetComparer(List<Sorter> list)
        {
            return new NodeComparer(list);
        }


        // apply to FlyingNode only, how to sort FlyingNode
        public class NodeComparer : IComparer<AirportDto>
        {
            private List<Sorter> list;

            // define sort field list
            public NodeComparer(List<Sorter> list)
            {
                this.list = list;
            }

            // inplement IComparer interface
            public int Compare(AirportDto x, AirportDto y)
            {
                int result = 0;
                foreach (Sorter item in list)
                {
                    result = Compare(x, y, item.Field, item.Direction);
                    if (result != 0)		// once result =0，means comparison finished, break
                        break;
                }

                return result;
            }

            public int Compare(AirportDto x, AirportDto y, SortField field, SortDirection direction)
            {
                var result = 0;			// default location of sort 

                switch (field)
                {
                    case SortField.Id:
                        if (direction == SortDirection.Ascending)
                            result = string.CompareOrdinal(x.Id, y.Id);
                        else
                            result = string.CompareOrdinal(x.Id, y.Id);
                        break;
                    case SortField.LengthStartMiddle:
                        if (direction == SortDirection.Ascending)
                            result = x.LengthStartMiddle.CompareTo(y.LengthStartMiddle);
                        else
                            result = y.LengthStartMiddle.CompareTo(x.LengthStartMiddle);
                        break;
                    case SortField.LengthMiddleEnd:
                        if (direction == SortDirection.Ascending)
                            result = x.LengthMiddleEnd.CompareTo(y.LengthMiddleEnd);
                        else
                            result = y.LengthMiddleEnd.CompareTo(x.LengthMiddleEnd);
                        break;

                }
                return result;
            }
        }
    }
}
