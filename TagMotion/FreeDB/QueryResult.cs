using System;

namespace Freedb
{
	public class QueryResult
	{
		private string _ResponseCode;
		private string _Genre;
		private string _DiscID;
		private string _Artist;
		private string _Title;
		
		
		public string ResponseCode
		{
			get { return _ResponseCode; }
			set	{ _ResponseCode = value; }
		}

		public string Genre
		{
			get	{ return _Genre; }
			set	{ _Genre = value; }
		}

		public string Discid
		{
			get	{ return _DiscID; }
			set	{ _DiscID = value; }
		}

		public string Artist
		{
			get	{ return _Artist; }
			set	{ _Artist = value; }
		}
		
		public string Title
		{
			get	{ return _Title; }
			set { _Title = value; }
		}
		
		

		public QueryResult(string queryResult)
		{
			if (!Parse(queryResult,false))
				throw new Exception("Unable to Parse QueryResult. Input: " + queryResult);
		}

		/// <summary>
		/// The parsing for a queryresult returned as part of a number of matches is slightly different
		/// There is no response code
		/// </summary>
		/// <param name="queryResult"></param>
		/// <param name="multiMatchInput"> true if the result is part of multi-match which means it will not contain a response code</param>
		public QueryResult(string queryResult, bool multiMatchInput)
		{
			if (!Parse(queryResult,multiMatchInput))
				throw new Exception("Unable to Parse QueryResult. Input: " + queryResult);
		}

		/// <summary>
		/// Parse the query result line from the cddb server
		/// </summary>
		/// <param name="queryResult"></param>
		public bool Parse(string queryResult,bool match)
		{
            try
            {
                queryResult.Trim();
                int secondIndex = 0;

                // get first white space
                int index = queryResult.IndexOf(' ');

                //if we are parsing a matched queryresult there is no responsecode so skip it
                if (!match)
                {
                    _ResponseCode = queryResult.Substring(0, index);
                    index++;
                    secondIndex = queryResult.IndexOf(' ', index);
                }
                else
                {
                    secondIndex = index;
                    index = 0;
                }

                _Genre = queryResult.Substring(index, secondIndex - index);
                index = secondIndex;
                index++;
                secondIndex = queryResult.IndexOf(' ', index);

                _DiscID = queryResult.Substring(index, secondIndex - index);
                index = secondIndex;
                index++;
                secondIndex = queryResult.IndexOf('/', index);

                _Artist = queryResult.Substring(index, secondIndex - index - 1); // -1 because there is a space at the end of artist
                index = secondIndex;
                index += 2; //skip past / and space

                _Title = queryResult.Substring(index);

                return true;
            }
            catch
            {
                return false;
            }
		}

//		public bool Parse(string queryResult)
//		{
//			queryResult.Trim();
//			string [] values = queryResult.Split(' ');
//			if (values.Length <6)
//				return false;
//			this.m_ResponseCode = values[0];
//			m_Category = values[1];
//			m_Discid = values[2];
//
//			// now we need to look for a slash
//			bool artist = true;
//			for (int i = 3; i < values.Length;i++)
//			{
//				if (values[i] == "/")
//				{
//					artist = false;
//					continue;
//				}
//				if (artist)
//					this.m_Artist += values[i];
//				else
//					this.m_Title += values[i];
//
//			}
//			return true;
//		}

		public override string ToString()
		{
			return this._Artist + ", " + this._Title;
		}

	}
}
