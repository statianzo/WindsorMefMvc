namespace WindsorMefMvc.Web.Framework
{
	public interface IBootstrapperTask
	{
		int Order { get; }
		void Execute();	
	}
}