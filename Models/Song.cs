/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 25/11/2020
 * Time: 3:21 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of Song.
	/// </summary>
	public class Song
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Artist { get; set; }
		public string Writer { get; set; }
		public string Genre { get; set; }
		public string ReleaseDate { get; set; }
	}
}
