using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataContext
{
        public class DataUtility
        {
            private readonly ProductContext _context;

            protected DataUtility(ProductContext context)
            {
                _context = context;
            }

            protected IEnumerable<T> ExecuteQuery<T>(string commandText, params object[]? parameters) where T : class
            {
                List<T> resultSet = new List<T>();
                if (parameters == null) return resultSet;
                var paramNames = string.Join("", parameters.Select(a => a + " "));
                resultSet = _context.Set<T>().FromSqlRaw(commandText + ' ' + paramNames, parameters).ToList();

                return resultSet;
            }
              protected List<T> GetData<T>(string commandText, params object[]? parameters) where T : class
             {
                List<T> resultSet = new List<T>();

                if (parameters == null) return resultSet;
                resultSet = _context.Set<T>().FromSqlRaw(commandText, parameters).ToList();

                return resultSet;
             }



            protected List<T> GetData<T>(string commandText, SqlParameter[]? parameters) where T : class
            {
                List<T> resultSet = new List<T>();

                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        if (parameter.Value is null)
                        {
                            parameter.Value = "null";
                        }
                        else if (parameter.Value is string)
                        {
                            parameter.Value = "'" + parameter.Value + "'";
                        }
                        else if (parameter.Value is DateTime)
                        {
                            parameter.Value = "'" + ((DateTime)parameter.Value).ToString("yyyy-MM-dd HH:mm:ss") + "'";

                        }
                        else
                        {
                            parameter.Value = parameter.Value;
                        }
                        commandText = commandText + " " + parameter.ParameterName + " = " + parameter.Value + ", ";
                    }


                    resultSet = _context.Set<T>().FromSqlRaw(parameters.Count() > 0 ? commandText.Remove(commandText.TrimEnd().Length - 1, 1) : commandText, parameters).ToList();
                }

                return resultSet;
            }

            protected List<DynamicObject> GetDataNew<T>(string commandText, SqlParameter[]? parameters) where T : class
            {
                List<DynamicObject> resultSet = new List<DynamicObject>();

                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        if (parameter.Value is null)
                        {
                            parameter.Value = "null";
                        }
                        else if (parameter.Value is string)
                        {
                            parameter.Value = "'" + parameter.Value + "'";
                        }
                        else if (parameter.Value is DateTime)
                        {
                            parameter.Value = "'" + ((DateTime)parameter.Value).ToString("yyyy-MM-dd HH:mm:ss") + "'";

                        }
                        else
                        {
                            parameter.Value = parameter.Value;
                        }
                        commandText = commandText + " " + parameter.ParameterName + " = " + parameter.Value + ", ";
                    }
                    commandText = parameters.Count() > 0 ? commandText.Remove(commandText.TrimEnd().Length - 1, 1) : commandText;

                    resultSet = _context.Set<DynamicObject>().FromSqlRaw(commandText, parameters).ToList();
                }

                return resultSet;
            }


            /// <summary>
            /// this is used for record management page services . need to change
            /// </summary>
            /// <param name="commandText"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            protected string InsertOrUpdate(string commandText, params object?[]? parameters)
            {
                if (parameters != null)
                {
                    string.Join("", parameters.Select(a => a + ","));
                }

                var firstId = _context.Database.ExecuteSqlRaw(commandText, parameters!).ToString();

                return firstId;
            }

            protected int InsertOrUpdate(string commandText, Dictionary<string, object?> parameters)
            {

                var parameterReturn = new SqlParameter
                {
                    ParameterName = "@ReturnValue",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output
                };

                var query = string.Join(",", parameters.Select(a =>
                {
                    if (a.Value is null)
                    {
                        return $"{a.Key}=null";
                    }
                    else if (a.Value is string)
                    {
                        return $"{a.Key}='{a.Value}'";
                    }
                    else if (a.Value is DateTime)
                    {
                        var dateTimeValue = ((DateTime)a.Value).ToString("yyyy-MM-dd HH:mm:ss");
                        return $"{a.Key}='{dateTimeValue}'";
                    }
                    else
                    {
                        return $"{a.Key}={a.Value}";
                    }
                }));

                var commandTextWithReturnValue = $"EXEC {commandText} {query.TrimEnd(',')}," + $" @ReturnValue = @ReturnValue OUTPUT;";

                _context.Database.ExecuteSqlRaw(commandTextWithReturnValue, parameterReturn);

                var returnValue = parameterReturn.Value == DBNull.Value ? 0 : Convert.ToInt32(parameterReturn.Value);

                return returnValue;
            }


        }

    }

