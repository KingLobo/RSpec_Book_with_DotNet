namespace Codebreaker.Spec
{
    using Codebreaker.Lib;

    using FluentAssertions;

    using Machine.Specifications;

    [Subject(typeof(Marker))]
    public class Marker_spec
    {
        public static Marker Marker;

        public class Exact_match_count
        {
            [Subject(typeof(Marker), "#Exact match count")]
            public class With_no_matches
            {
                Because of = () =>
                    {
                        Marker = new Marker(
                            "1234",
                            "5555");
                    };

                It should_return_0 = () => Marker.ExactMatchCount().Should().Be(0);
            }

            [Subject(typeof(Marker), "#Exact match count")]
            public class With_1_exact_match
            {
                Because of = () =>
                    {
                        Marker = new Marker("1234", "1555");
                    };

                It should_return_1 = () => Marker.ExactMatchCount().Should().Be(1);
            }

            [Subject(typeof(Marker), "#Exact match count")]
            public class With_1_number_match
            {
                Because of = () =>
                    {
                        Marker = new Marker("1234", "2555");
                    };

                It should_return_0 = () => Marker.ExactMatchCount().Should().Be(0);
            }

            [Subject(typeof(Marker), "#Exact match count")]
            public class With_1_exact_match_and_1_number_match
            {
                Because of = () =>
                    {
                        Marker = new Marker("1234", "1525");
                    };

                It should_return_1 = () => Marker.ExactMatchCount().Should().Be(1);
            }

        }

        [Subject(typeof(Marker))]
        public class Number_match_count
        {
            [Subject(typeof(Marker), "#Number match count")]
            public class With_no_matches
            {
                Because of = () =>
                    {
                        Marker = new Marker("1234", "5555");
                    };

                It should_return_0 = () => Marker.NumberMatchCount().Should().Be(0);
            }

            [Subject(typeof(Marker), "#Number match count")]
            public class With_1_number_match
            {
                Because of = () =>
                {
                    Marker = new Marker("1234", "2555");
                };

                It should_return_1 = () => Marker.NumberMatchCount().Should().Be(1);
            }

            [Subject(typeof(Marker), "#Number match count")]
            public class With_1_exact_match
            {
                Because of = () =>
                {
                    Marker = new Marker("1234", "1555");
                };

                It should_return_0 = () => Marker.NumberMatchCount().Should().Be(0);
            }

            [Subject(typeof(Marker), "#Number match count")]
            public class With_1_exact_match_and_1_number_match
            {
                Because of = () =>
                {
                    Marker = new Marker("1234", "1525");
                };

                It should_return_1 = () => Marker.NumberMatchCount().Should().Be(1);
            }
        }
    }
}
