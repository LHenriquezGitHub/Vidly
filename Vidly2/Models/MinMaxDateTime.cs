using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
    public class MinMaxReleaseDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var minDatetime = new DateTime(1900, 1, 1);
            var maxDatetime = new DateTime(3000, 1, 1);
            DateRange range = new DateRange(minDatetime, maxDatetime);

            return (range.Includes(movie.ReleaseDate)) ?
                ValidationResult.Success :
                new ValidationResult("The field release date must be between 1/1/1900 and 1/1/3000.");
        }
    }
    public class MinMaxAddedDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var minDatetime = new DateTime(1900, 1, 1);
            var maxDatetime = new DateTime(3000, 1, 1);
            DateRange range = new DateRange(minDatetime, maxDatetime);

            return (range.Includes(movie.DatedAdded)) ?
                ValidationResult.Success :
                new ValidationResult("The field added date must be between 1/1/1900 and 1/1/3000.");
        }
    }

    public interface IRange<T>
    {
        T Start { get; }
        T End { get; }
        bool Includes(T value);
        bool Includes(IRange<T> range);
    }

    public class DateRange : IRange<DateTime>
    {
        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public bool Includes(DateTime value)
        {
            return (Start <= value) && (value <= End);
        }

        public bool Includes(IRange<DateTime> range)
        {
            return (Start <= range.Start) && (range.End <= End);
        }
    }
} 